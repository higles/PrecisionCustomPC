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
        [MinLength(7)]
        [MaxLength(7)]
        [RegularExpression("[#]{1}[a-fA-f0-9]{6}")]
        public string ColorHash { get; set; }

        public List<Image> Images { get; set; } = new List<Image>();
    }
}
