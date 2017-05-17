using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrecisionCustomPC.Models.PartsViewModels
{
    public class Fan : Base.ColoredPart
    {
        [Required]
        [Display(Name = "Diameter")]
        public Options.FanSize Size { get; set; }
    }
}
