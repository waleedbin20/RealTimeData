using RealTimeMVCapp.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RealTimeMVCapp.Model
{
    public class MaterialViewModel
    {
        
        public int mId { get; set; }

        [Required]
        public int materialYFlag { get; set; }

        public ICollection<MaterialItemViewModel> materialItems { get; set; }
    }
}
