using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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

    [Route("api/[Controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private readonly IRealTimeRepository _repository;
        private readonly ILogger<MaterialController> _logger;
        private readonly IMapper _mapper;
        private readonly IHubContext<BroadcastHub, IHubClient> _hubContext;
        public MaterialController(IRealTimeRepository repository, ILogger<MaterialController> logger, IMapper mapper, IHubContext<BroadcastHub, IHubClient> hubContext)
        {
            _repository = repository;
          
            _logger = logger;
            _mapper = mapper;
            _hubContext = hubContext;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Material>> Get()
        {
            try
            {
                var allmaterials = _repository.GetAllMaterials();

             

                return Ok(_mapper.Map<IEnumerable<MaterialViewModel>>(allmaterials));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Not able to get all the materials {ex}");

                return BadRequest("Failed to get all Materials");
            }

        }

        [HttpGet("{id:int}")]
        public ActionResult<IEnumerable<Material>> Get(int id)
        {
            try
            {
                var materialsbyid = _repository.GetMaterialByID(id);

                if(materialsbyid != null)
                {
                    return Ok(_mapper.Map<Material, MaterialViewModel>(materialsbyid));
                    
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Not able to get material by Id's {ex}");
                return BadRequest();
            }
        }



        [HttpPost]
         public MaterialViewModel Post([FromBody] MaterialViewModel model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var newMaterial = _mapper.Map<MaterialViewModel, Material>(model);

                    _repository.AddEntity(newMaterial);

                    if (_repository.SaveAll())
                    {
                       var x =  Created($"api/material/{newMaterial.materialId}", _mapper.Map<Material, MaterialViewModel>(newMaterial));
                        _hubContext.Clients.All.BroadcastMessage(newMaterial.materialId, newMaterial.materialYFlag);

                        return x.Value as MaterialViewModel;
                    }
                   
                }

                else
                {
                    return null;

                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Not able to add materials {ex}");
            }
            return null;
        }


        [HttpPut("{id:int}")]
        public ActionResult<IEnumerable<Material>> Put(int id, [FromBody] MaterialViewModel model)
        {
            try
            {
                var getmaterial = _repository.GetMaterialByID(id);

                if (getmaterial == null) return NotFound();

                //_mapper.Map(model, getmaterial);
                getmaterial.materialYFlag = model.materialYFlag;
                if (_repository.SaveAll())
                {
                    Ok(_mapper.Map<MaterialViewModel>(getmaterial));
                    _hubContext.Clients.All.BroadcastMessage(getmaterial.materialId, getmaterial.materialYFlag);

                    return Ok();
                }
                else
                {
                    return BadRequest("Internal Server Error");
                }


            }
            catch (Exception ex)
            {
                _logger.LogError($"Not able to update values {ex}");
            }
            return BadRequest();
        }
    }
}
