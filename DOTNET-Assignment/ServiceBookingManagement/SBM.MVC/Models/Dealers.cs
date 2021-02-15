using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBM.MVC.Models
{
    public class Dealers
    {
        public int DealerId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is Required.")]
        public string DealerName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Address is Required.")]
        public string Address1 { get; set; }
        public string Address2 { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "ZipCode is Required.")]
        public string ZipCode { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "City is Required.")]
        public string City { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Country is Required.")]
        public string Country { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Contact Number is Required.")]
        public string ContactNo { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Email Id is Required.")]
        [DataType(DataType.EmailAddress)]
        public string EmailId { get; set; }

        public bool IsActive { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is Required.")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Enter atleast 8 characters.")]
        public string Password { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }

        //public virtual Appointments Appointment { get; set; }
        //public virtual Mechanics Mechanic { get; set; }
        //public virtual Services Service { get; set; }
    }
}
