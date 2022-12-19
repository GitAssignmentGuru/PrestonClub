using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PrestonClub.Models
{
    public class UserRegistration
    {
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Please enter the first name.")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Please enter the last name.")]
        public string LastName { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please enter the email address.")]
        [EmailAddress(ErrorMessage = "Please enter correct email address.")]
        public string Email { get; set; }
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Please enter the phone number.")]
        public string Phone_Number { get; set; }
        [Display(Name = "Address")]
        [Required(ErrorMessage = "Please enter the address.")]
        public string Address { get; set; }
        [Display(Name = "Select Participant")]
        public int ParticipantsID { get; set; }
        [Display(Name = "Participant Ranking")]
        public Nullable<int> WorldRanking { get; set; }
        [Display(Name = "Select Volunteer Type")]
        public Nullable<int> Volunteer_ID { get; set; }
        [Display(Name = "Password")]
        public string password { get; set; }
    }
}