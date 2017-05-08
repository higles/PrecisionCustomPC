using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static PrecisionCustomPC.Options;

namespace PrecisionCustomPC.Models.PartsViewModels
{
    public class Tower : Base.ColoredPart
    {
        [Required(ErrorMessage = "Size is required")]
        [DisplayName("Size:")]
        public Sizes Size { get; set; }

        [Required(ErrorMessage = "Fan count is required")]
        [Range(0, 10, ErrorMessage = "Fan count not in range")]
        [DisplayName("Fan Count:")]
        public Nullable<int> FanCount { get; set; }

        [Required(ErrorMessage = "Liquid Cooling compatibility is required")]
        [DisplayName("Liquid Cooling Compatible:")]
        public Nullable<bool> LiquidCooling { get; set; }
    }
}
