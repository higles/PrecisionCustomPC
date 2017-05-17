using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrecisionCustomPC.Models.PartsViewModels
{
    public class Color
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public Nullable<int> ID { get; set; }
        
        [Required]
        public Options.Color ColorValue { get; set; }

        public List<Image> Images { get; set; } = new List<Image>();
    }
}
