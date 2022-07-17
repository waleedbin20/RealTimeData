using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using RealTimeMVCapp.Data.Entities;
using RealTimeMVCapp.Model;
using RealTimeMVCapp.Repository;
using RealTimeMVCapp.SignalRHub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace RealTimeMVCapp.Controllers
{
    [Route("api/material/{materialid}/items")]
    [ApiController]
    public class MaterialItemController : ControllerBase
    {
        private readonly IRealTimeRepository _repository;
        private readonly ILogger<MaterialItemController> _logger;
        private readonly IMapper _mapper;
        private readonly IHubContext<BroadcastHub, IHubClient> _hubContext;

        public MaterialItemController(IRealTimeRepository repository, ILogger<MaterialItemController> logger, IMapper mapper, IHubContext<BroadcastHub, IHubClient> hubContext)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
            _hubContext = hubContext;
        }

        [HttpGet]
        public IActionResult Get(int materialId)
        {
            var material = _repository.GetMaterialByID(materialId);
            
            if(material != null)
            {
                return Ok(_mapper.Map<IEnumerable<MaterialItems>, IEnumerable<MaterialItemViewModel>>(material.materialItems));
            }
            return NotFound();
        }

        [HttpGet("{materialItemId}")]
        public IActionResult Get(int materialId,int materialItemId)
        {
            var material = _repository.GetMaterialByID(materialId);

            if (material != null)
            {
                var items = material.materialItems.Where(i => i.materialItemsId == materialItemId).FirstOrDefault();

                if (items != null)
                {

                    return Ok(_mapper.Map<MaterialItems, MaterialItemViewModel>(items));
                }
            }
            return NotFound();
        }


        [HttpPost]

        public IActionResult Post(int materialId, [FromBody] MaterialItemViewModel model)
        {

            try
            {
                if(ModelState.IsValid)
                {
                    var getMaterial = _repository.GetMaterialByID(materialId);
                    var newMaterialItem = _mapper.Map<MaterialItemViewModel, MaterialItems>(model);

                    newMaterialItem.material = getMaterial;

                    _repository.AddEntity(newMaterialItem);

                    if(_repository.SaveAll())
                    {
                        Created($"/api/orders/{materialId}/items/{newMaterialItem.materialItemsId}", _mapper.Map<MaterialItemViewModel>(newMaterialItem));

                        _hubContext.Clients.All.BroadcastMaterialItem(materialId, newMaterialItem.materialDescription);

                        return Ok();
                    }
                }
            }
            catch (Exception ex)
            {

                _logger.LogError($"Not able to post items inside the material {ex}");

               
            }
            return BadRequest();
        }
        

    }
}
