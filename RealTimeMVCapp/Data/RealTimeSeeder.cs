using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using RealTimeMVCapp.Context;
using RealTimeMVCapp.Data.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

/*namespace RealTimeMVCapp.Data
{
    public class RealTimeSeeder
    {
        private readonly RealTimeContext _context;
        private readonly IWebHostEnvironment _env;

        public RealTimeSeeder (RealTimeContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public void seedMaterials()
        {
            // we need to check if the database is created - this resolves from having exceptions
            _context.Database.EnsureCreated();

            // Need to create Sample data
            var filePath = Path.Combine(_env.ContentRootPath, "Data//Materia.json");
            var json = File.ReadAllText(filePath);

            // art.json matches the structure of the product class
            var products = JsonConvert.DeserializeObject<IEnumerable<Material>>(json);

            // return a material if its empty
            if (!_context.Material.Any())
            {
                // now you will create a new material

                var material = new Material
                {
                    materialYFlag = 2,
                    materialItems = new List<MaterialItems>
                    {
                        new MaterialItems()
                        {
                            materialDescription = "Beef Potatoes"
                        }
                    }
                };

                // now add the material 

                _context.Material.Add(material);

                _context.SaveChanges();


            }
        }
    }
}
*/