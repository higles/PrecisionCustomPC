using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrecisionCustomPC.Models.PartsViewModels
{
    public class Storage : Base.ColorlessPart
    {
        [Required]
        [Display(Name = "Form Factor")]
        public Options.FormFactor FormFactor { get; set; }

        [Required]
        [Range(100, 10000)]
        [Display(Name = "Size in GB")]
        public Nullable<int> Size { get; set; }
    }
}
