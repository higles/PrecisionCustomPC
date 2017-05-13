using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrecisionCustomPC.Models.PartsViewModels.Base
{
    public class ColorlessPart : Part
    {
        [HiddenInput(DisplayValue = false)]
        public Color Color { get; set; }
    }
}
