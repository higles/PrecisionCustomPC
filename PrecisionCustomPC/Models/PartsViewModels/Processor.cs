﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrecisionCustomPC.Models.PartsViewModels
{
    public class Processor : Base.ColorlessPart
    {
        [Required]
        [Range(2, 5)]
        [Display(Name = "Clock Speed:")]
        public float Speed { get; set; }

        [Required]
        [Range(2, 10)]
        [Display(Name = "Number of Cores:")]
        public int Cores { get; set; }
        
        [Required]
        [Display(Name = "Cooling Fan Included:")]
        public bool Cooler { get; set; }
    }
}