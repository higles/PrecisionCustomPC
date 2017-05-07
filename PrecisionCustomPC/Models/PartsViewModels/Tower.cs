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
    public class Tower
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public Nullable<int> ID { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0, 10000, ErrorMessage = "Price out of range")]
        [DisplayName("Price:")]
        public Nullable<int> Price { get; set; }

        [Required(ErrorMessage = "Brand is required")]
        [MinLength(3, ErrorMessage = "Brand name too short")]
        [DisplayName("Brand:")]
        public string Brand { get; set; }

        [MinLength(3, ErrorMessage = "Series name too short")]
        [DisplayName("Series:")]
        public string Series { get; set; }

        [Required(ErrorMessage = "Model is required")]
        [MinLength(3, ErrorMessage = "Model name too short")]
        [DisplayName("Model:")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Size is required")]
        [DisplayName("Size:")]
        public Sizes Size { get; set; }

        [DisplayName("Colors:")]
        public List<Color> Colors { get; set; } = new List<Color>();

        [Required(ErrorMessage = "Fan count is required")]
        [Range(0, 10, ErrorMessage = "Fan count not in range")]
        [DisplayName("Fan Count:")]
        public Nullable<int> FanCount { get; set; }

        [Required(ErrorMessage = "Liquid Cooling compatibility is required")]
        [DisplayName("Liquid Cooling Compatible:")]
        public Nullable<bool> LiquidCooling { get; set; }
    }
}
