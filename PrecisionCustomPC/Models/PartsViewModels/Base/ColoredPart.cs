using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace PrecisionCustomPC.Models.PartsViewModels.Base
{
    public class ColoredPart : Part
    {
        [HiddenInput(DisplayValue = false)]
        public List<Color> Colors { get; set; } = new List<Color>();
    }
}
