using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBM.MVC.Models
{
    public class Mechanics
    {
        public int MechanicId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Mechanic Name is Required.")]
        public string MechanicName { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Contact No. is Required.")]
        public string ContactNo { get; set; }
        
        public string Make { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email ID is Required.")]
        [DataType(DataType.EmailAddress)]
        public string EmailId { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "isActive is Required.")]
        public bool isActive { get; set; }

        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Dealer Id is Required.")]
        public int DealerId { get; set; }

        //public virtual Dealers Dealer { get; set; }
        //public virtual ICollection<JobCards> JobCards { get; set; }
    }
}
