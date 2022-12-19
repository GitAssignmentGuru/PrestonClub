using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PrestonClub.Models
{
    public class LoginModel
    {

        [Display(Name = "EmailID")]
        [Required(ErrorMessage = "Please enter the username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please enter the password")]
        public string Password { get; set; }
    }
}