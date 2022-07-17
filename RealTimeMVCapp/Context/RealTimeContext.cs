using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using RealTimeMVCapp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealTimeMVCapp.Context
{
    public class RealTimeContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public RealTimeContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // we need the entity now
        public DbSet<Material> Material { get; set;}

        public DbSet<MaterialItems> MaterialItems { get; set; }


        // now set the connectionstring
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(_configuration["ConnectionStrings:RealTimeContextDb"]);
        }




    }
}
