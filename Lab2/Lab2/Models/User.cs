using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab2.Models
{
    public class User
    {
        [Required]
        [MaxLength(25)]
        [MinLength(3)]       
        [RegularExpression("^[01]?[- .]?\\(?[2-9]\\d{2}\\)?[- .]?\\d{3}[- .]?\\d{4}$",
        ErrorMessage = "Special character not allowed.")]
        public string Name { get; set; }
        [Required]
        [RegularExpression("^([0-9][0-9])-([0-9]+)-([1-3])@student.aiub.edu", ErrorMessage = "You have to use your AIUB email address.")]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^(?:(?:\+|00)88|01)?\d{11}$", ErrorMessage = "Only Bangladeshi number allowed.")]
        public string Phone { get; set; }
        [Required]
        public string DoB { get; set; }
        [Required]
        public string Blood_Group { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        [MinLength(8)]
        public string password { get; set; }
        [Compare("password")]
        public string ConPass { get; set; }

    }
}