using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using SourceControlFinalAssignment.Custom_Validation;

namespace SourceControlFinalAssignment.Models
{
    [MetadataType(typeof(RegisterUserMetadata))]
    public partial class RegisterUser
    {
        public string ConfirmPassword { get; set; }
    }

    public class RegisterUserMetadata
    {
        [Display(Name = "First Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "First Name Required")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last Name Required")]
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email Id Required")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid")]
        public string EmailID { get; set; }

        [Display(Name = "Age")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Age is Required")]
        [Range(18, 60, ErrorMessage = "Age must be between 18 to 60")]
        public Nullable<int> Age { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is Required")]
        [MinLength(8, ErrorMessage = "Minimum 6 charaxters required")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Confirm Password is Required")]
        [MinLength(8, ErrorMessage = "Minimum 6 charaxters required")]
        [Compare("Password", ErrorMessage = "Confirm Password and Password do not match")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Phone")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Contact number is Required")]
        [MaxLength(10)]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Display(Name = "Address")]
        [DataType(DataType.MultilineText)]
        [MaxWordAttributes(80)]
        public string Address { get; set; }

        [Display(Name = "Profile Picture")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Upload Picture")]
        public string ProfileImage { get; set; }
    }
}