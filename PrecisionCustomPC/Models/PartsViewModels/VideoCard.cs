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
        [Range(2, 20)]
        [Display(Name = "Memory:")]
        public int Memory { get; set; }
        
        [Range(1000, 3000)]
        [Display(Name = "Clock Speed")]
        public Nullable<float> Speed { get; set; }

        [Required]
        [Range(50, 800)]
        [Display(Name = "Watts:")]
        public int Power { get; set; }
    }
}
