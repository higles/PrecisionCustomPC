using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrecisionCustomPC.Models.PartsViewModels
{
    public class Memory : Base.ColoredPart
    {
        [Required]
        [Display(Name = "Memory Standard:")]
        public Options.RAMClasse Class { get; set; }

        [Required]
        [Display(Name = "Memory Size:")]
        public Options.RAMSize Size { get; set; }

        [Required]
        [Range(1600, 6000)]
        [Display(Name = "Clock Speed:")]
        public float Speed { get; set; }
    }
}
