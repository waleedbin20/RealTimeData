using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RealTimeMVCapp.Context;
using RealTimeMVCapp.Data.Entities;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace RealTimeMVCapp.Repository
{
    public class RealTimeRepository : IRealTimeRepository
    {
        private readonly RealTimeContext _context;
        private readonly ILogger _logger;
       

        public RealTimeRepository(RealTimeContext context, ILogger<RealTimeRepository> logger)
        {
            _context = context;
            _logger = logger;
            
        }

        // method to add data to an entity

        public void AddEntity(object model)
        {
            _context.Add(model);
        }


        public Material GetMaterialByID(int id)
        {
            return _context.Material
                .Include(o => o.materialItems)
                .Where(o => o.materialId == id)
                .FirstOrDefault();
        }

        public IEnumerable<Material> GetAllMaterials()
        {
            return _context.Material
                .OrderBy(p => p.materialId)
                .Include(o => o.materialItems)
                .ToList();

        }

      

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }


        
        



    }
}
