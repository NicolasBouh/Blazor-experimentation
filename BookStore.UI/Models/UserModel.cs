using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.UI.Models
{
    public class RegistrationModel
    {
        [Required]
        [EmailAddress]
        [Display(Name= "Email Address")]
        public string EmailAddress { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(15, ErrorMessage = "Your password is limited to {2} to {1}", MinimumLength = 6)]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [StringLength(15, ErrorMessage = "Your password is limited to {2} to {1}", MinimumLength = 6)]
        public string ConfirmPassword { get; set; }
    }

    public class LoginModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
