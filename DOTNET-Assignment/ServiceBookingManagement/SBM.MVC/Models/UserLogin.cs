using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SBM.MVC.Models
{
    public class UserLogin
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "UserType is Required.")]
        public UserType User { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email Id is Required.")]
        [DataType(DataType.EmailAddress)]
        public string EmailId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is Required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }

    public enum UserType
    {
        Dealer,
        Customer
    }
}