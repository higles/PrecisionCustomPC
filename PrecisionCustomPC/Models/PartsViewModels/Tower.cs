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
        [Required]
        [DisplayName("Size")]
        public TowerSize Size { get; set; }

        [Required]
        [Range(0, 10)]
        [DisplayName("Fan Count")]
        public Nullable<int> FanCount { get; set; }

        [Required]
        [DisplayName("Liquid Cooling Compatible")]
        public Nullable<bool> LiquidCooling { get; set; }

        [DisplayName("Optical Drive")]
        public Nullable<bool> OpticalDrive { get; set; }
    }
}
