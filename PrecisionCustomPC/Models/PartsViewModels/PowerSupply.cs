using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrecisionCustomPC.Models.PartsViewModels
{
    public class PowerSupply : Base.ColorlessPart
    {
        [Required]
        [Range(400, 1500)]
        [Display(Name = "Watts:")]
        public int Power { get; set; }

        [Required]
        [Display(Name = "Modular:")]
        public Options.Modular Modular { get; set; }
    }
}
