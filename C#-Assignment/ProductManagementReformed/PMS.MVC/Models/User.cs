using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.MVC.Models
{
    public class User
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public tblUser()
        //{
        //    this.tblProducts = new HashSet<tblProduct>();
        //}

        public int UserId { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is Required.")]
        public string Name { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "EmailId is Required.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email Id is not in correct format.")]
        public string EmailId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Please enter atleast 8 characters.")]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Contact No. is Reqquired.")]
        public string ContactNo { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<tblProduct> tblProducts { get; set; }
    }
}
