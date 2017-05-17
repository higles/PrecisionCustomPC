using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrecisionCustomPC.Models.PartsViewModels.Base
{
    public class Part
    {
        [Key]
        [Display(Order = 0)]
        [ScaffoldColumn(false)]
        public int ID { get; set; }

        [Display(Order = 1)]
        [Required]
        [Range(0, 10000)]
        [DisplayName("Price")]
        public Nullable<int> Price { get; set; }

        [Display(Order = 2)]
        [Required]
        [MinLength(3)]
        [DisplayName("Brand")]
        public string Brand { get; set; }

        [Display(Order = 3)]
        [MinLength(3)]
        [DisplayName("Series")]
        public string Series { get; set; }

        [Display(Order = 4)]
        [Required]
        [MinLength(3)]
        [DisplayName("Model")]
        public string Model { get; set; }
    }
}
