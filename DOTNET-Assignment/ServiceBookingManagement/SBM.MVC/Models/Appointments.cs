using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBM.MVC.Models
{
    public class Appointments
    {
        public int AppintmentId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Service ID is Required.")]
        public int ServiceId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Dealer ID is Required.")]
        public int DealerId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Customer ID is Required.")]
        public int CustomerId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Booking Date Time is Required.")]
        [DataType(DataType.DateTime)]
        public System.DateTime BookingDateTime { get; set; }
        
        
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }

        //public virtual Customers Customer { get; set; }
        //public virtual Dealers Dealer { get; set; }
        //public virtual Services Service { get; set; }
        //public virtual ICollection<JobCards> JobCards { get; set; }
    }
}
