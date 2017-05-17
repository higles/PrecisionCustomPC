using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrecisionCustomPC.Models.PartsViewModels
{
    public class VideoCard : Base.ColoredPart
    {
        [Required]
        [Display(Name = "Memory")]
        public Options.RAMSize Memory { get; set; }
        
        [Range(1000, 3000)]
        [Display(Name = "Clock Speed")]
        public Nullable<int> Speed { get; set; }

        [Required]
        [Range(50, 800)]
        [Display(Name = "Watts")]
        public Nullable<int> Power { get; set; }
    }
}
