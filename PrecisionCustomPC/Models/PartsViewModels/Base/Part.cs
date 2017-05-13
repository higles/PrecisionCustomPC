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
        [Required(ErrorMessage = "Price is required")]
        [Range(0, 10000, ErrorMessage = "Price out of range")]
        [DisplayName("Price:")]
        public Nullable<int> Price { get; set; }

        [Display(Order = 2)]
        [Required(ErrorMessage = "Brand is required")]
        [MinLength(3, ErrorMessage = "Brand name too short")]
        [DisplayName("Brand:")]
        public string Brand { get; set; }

        [Display(Order = 3)]
        [MinLength(3, ErrorMessage = "Series name too short")]
        [DisplayName("Series:")]
        public string Series { get; set; }

        [Display(Order = 4)]
        [Required(ErrorMessage = "Model is required")]
        [MinLength(3, ErrorMessage = "Model name too short")]
        [DisplayName("Model:")]
        public string Model { get; set; }
    }
}
