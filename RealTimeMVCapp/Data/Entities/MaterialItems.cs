using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealTimeMVCapp.Data.Entities
{
    public class MaterialItems
    {
        public int materialItemsId { get; set; }

        public string materialDescription { get; set; }

        public Material material { get; set; }
    }
}
