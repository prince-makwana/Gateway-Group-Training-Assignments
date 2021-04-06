using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Models
{
    public class UserVM
    {
        public long ID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is Required")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Email Id is Required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Minimum 8 characters are required")]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Mobile Number is Required")]
        [StringLength(10, ErrorMessage = "Please Enter 10 digits Mobile Number")]
        public string Mobile { get; set; }
    }
}
