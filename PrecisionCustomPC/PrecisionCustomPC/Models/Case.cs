using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static PrecisionCustomPC.Options;

namespace PrecisionCustomPC.Models
{
    public class Case
    {
        [Required(ErrorMessage = "Price is required")]
        [Range(0, 10000, ErrorMessage = "Price out of range")]
        [DisplayName("Price:")]
        public int Price { get; set; }

        [Required(ErrorMessage = "Brand is required")]
        [MinLength(3, ErrorMessage = "Brand name too short")]
        [DisplayName("Brand:")]
        public string Brand { get; set; }

        [MinLength(3, ErrorMessage = "Series name too short")]
        [DisplayName("Series:")]
        public string Series { get; set; }

        [Key]
        [MinLength(3, ErrorMessage = "Model name too short")]
        [DisplayName("Model:")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Size is required")]
        [DisplayName("Size:")]
        public Sizes Size { get; set; }

        [DisplayName("Colors:")]
        public List<String> Colors { get; set; }

        [Required(ErrorMessage = "Fan count is required")]
        [Range(0, 10, ErrorMessage = "Fan count not in range")]
        [DisplayName("Fan Count:")]
        public int FanCount { get; set; }

        [Required(ErrorMessage = "Liquid Cooling compatibility is required")]
        [DisplayName("Liquid Cooling Compatible:")]
        public bool LiquidCooling { get; set; }
    }
}
