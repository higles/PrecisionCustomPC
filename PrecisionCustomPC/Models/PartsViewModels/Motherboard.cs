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
    public class Motherboard : Base.ColorlessPart
    {
        [Required]
        [DisplayName("Size")]
        public TowerSize Size { get; set; }

        [Required]
        [DisplayName("Maximum Memory")]
        public RAMSize MaxRAM { get; set; }

        [Required]
        [DisplayName("Memory Standard")]
        public RAMClass RAMClass { get; set; }

        [Required]
        [Range(0, 10)]
        [DisplayName("Memory Slots")]
        public Nullable<int> RamSlots { get; set; }

        [Range(0, 10)]
        [DisplayName("PCI Express Slots")]
        public Nullable<int> PCISlots { get; set; }

        [Range(0, 10)]
        [DisplayName("USB 3.0 Slots")]
        public Nullable<int> USB3Slots { get; set; }

        [Range(0, 10)]
        [DisplayName("M2 Slots")]
        public Nullable<int> M2Slots { get; set; }
    }
}
