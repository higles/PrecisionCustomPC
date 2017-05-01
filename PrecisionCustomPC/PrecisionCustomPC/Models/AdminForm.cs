using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrecisionCustomPC.Models
{
    public class AdminForm
    {
        [Required]
        [RegularExpression("Admin", ErrorMessage = "Username not found")]
        public string Username { get; set; }

        [Required]
        [RegularExpression("password", ErrorMessage = "Incorrect Password")]
        public string Password { get; set; }
    }
}
