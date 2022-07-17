using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealTimeMVCapp.Data.Entities
{
    public class Material
    {
        public int materialId { get; set; }
        public int materialYFlag { get; set; }

        public ICollection<MaterialItems> materialItems { get; set; }
    }
}
