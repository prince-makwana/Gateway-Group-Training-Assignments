using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMT.Models
{
    public class PassengerViewModel
    {
        public int ID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "First Name is Required.")]
        [DisplayName("First Name")]
        public string FName { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last Name is Required.")]
        [DisplayName("Last Name")]
        public string LName { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Mobile No. is Required.")]
        [DisplayName("Mobile Number")]
        public string MobileNo { get; set; }
    }
}
