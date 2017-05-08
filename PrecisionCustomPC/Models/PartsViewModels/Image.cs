using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrecisionCustomPC.Models.PartsViewModels
{
    public class Image
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public Nullable<int> ID { get; set; }

        [Required]
        [RegularExpression("(((https://)|(http://))?(www[.][^.]*[.])?[^.]*[.]((jpg)|(jpeg)|(JPG)|(gif)|(png)|(bmp)))")]
        public string ImagePath { get; set; }
    }
}
