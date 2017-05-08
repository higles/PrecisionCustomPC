﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static PrecisionCustomPC.Options;

namespace PrecisionCustomPC.Models.PartsViewModels
{
    public class Motherboard : Base.NonColoredPart
    {
        [Required(ErrorMessage = "Size is required")]
        [DisplayName("Size:")]
        public Sizes Size { get; set; }

        [Required(ErrorMessage = "Maximum Memory is required")]
        [DisplayName("Maximum Memory:")]
        public RAMSizes MaxRAM { get; set; }

        [DisplayName("Memory Standard:")]
        public RAMClasses RAMClass { get; set; }

        [Required(ErrorMessage = "Memory slots is required")]
        [Range(0, 10, ErrorMessage = "Number of memory slots is out of range")]
        [DisplayName("Memory Slots:")]
        public Nullable<int> RamSlots { get; set; }

        [Range(0, 10, ErrorMessage = "Number of PCI slots is out of range")]
        [DisplayName("PCI Express Slots:")]
        public Nullable<int> PCISlots { get; set; }

        [Range(0, 10, ErrorMessage = "Number of USB 3.0 slots is out of range")]
        [DisplayName("USB 3.0 Slots:")]
        public Nullable<int> USB3Slots { get; set; }
    }
}
