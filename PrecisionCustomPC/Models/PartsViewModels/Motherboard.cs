using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static PrecisionCustomPC.Options;

namespace PrecisionCustomPC.Models.PartsViewModels
{
    public class Motherboard
    {
        [Required(ErrorMessage = "")]
        [Range(0, 10000, ErrorMessage = "")]
        [DisplayName("Price:")]
        public int Price { get; set; }

        [Required(ErrorMessage = "")]
        [MinLength(3, ErrorMessage = "")]
        [DisplayName("Brand:")]
        public string Brand { get; set; }

        [MinLength(3, ErrorMessage = "")]
        [DisplayName("Series:")]
        public string Series { get; set; }

        [Key]
        [MinLength(3, ErrorMessage = "")]
        [DisplayName("Model:")]
        public string Model { get; set; }

        [Required(ErrorMessage = "")]
        [DisplayName("Size:")]
        public Sizes Size { get; set; }

        [Required(ErrorMessage = "")]
        [DisplayName("Maximum Memory:")]
        public RAMSizes MaxRAM { get; set; }

        [DisplayName("Memory Standard:")]
        public RAMClasses RAMClass { get; set; }

        [Required(ErrorMessage = "")]
        [Range(0, 10, ErrorMessage = "")]
        [DisplayName("Memory Slots:")]
        public int RamSlots { get; set; }

        [Range(0, 10, ErrorMessage = "")]
        [DisplayName("PCI Express Slots:")]
        public int PCISlots { get; set; }

        [Range(0, 10, ErrorMessage = "")]
        [DisplayName("USB 3.0 Slots:")]
        public int USB3Slots { get; set; }
    }
}
