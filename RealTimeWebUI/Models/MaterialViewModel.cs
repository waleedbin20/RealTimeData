
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace RealTimeWebUI.Model
{
    public class MaterialViewModel
    {
        
        public int mId { get; set; }

        [Required]
        public int materialNumber { get; set; }

        [Required]
        public string materialYFlag { get; set; }

        public virtual MaterialItemViewModel materialItems { get; set; }
    }
}
