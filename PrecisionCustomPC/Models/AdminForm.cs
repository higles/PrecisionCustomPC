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
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public bool isValid(string username, string password)
        {
            if (username.Equals("Admin") && password.Equals("password"))
            {
                return true;
            }
            return false;
        }
    }
}
