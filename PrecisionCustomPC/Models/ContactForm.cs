using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace PrecisionCustomPC.Models
{
    public class ContactForm
    {
        [Required(ErrorMessage = "First Name is required")]
        [MinLength(3, ErrorMessage = "FirstName must be at least 3 characters long")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [MinLength(3, ErrorMessage = "Last Name must be at least 3 characters long")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [MinLength(2, ErrorMessage = "Company Name too short")]
        [DisplayName("Company Name")]
        public string Company { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [MinLength(3, ErrorMessage = "Email is too short")]
        [DisplayName("Email")]
        public string Email { get; set; }

        [MinLength(10, ErrorMessage = "Phone number too short")]
        [MaxLength(15, ErrorMessage = "Phone number too long")]
        [DisplayName("Phone Number")]
        public string Phone { get; set; }
        
        [Range(0, 10000, ErrorMessage = "Min Value outside of allowed range: 0 - 10,000")]
        [DisplayName("Min Price")]
        public int? Min { get; set; }

        [Range(0, 10000, ErrorMessage = "Max Value outside of allowed range: 0 - 10,000")]
        [DisplayName("Max Price")]
        public int? Max { get; set; }

        [DisplayName("Message Box")]
        public string Msg { get; set; }
    }
}
