using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBM.MVC.Models
{
    public class JobCards
    {
        public int JobCardId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Mechanic Id is Required.")]
        public int MechanicId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Appoinment ID is Required.")]
        public int AppointmentId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Total Price is Required.")]
        public double TotalPrice { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Start DateTime is Required.")]
        [DataType(DataType.DateTime)]
        public System.DateTime StartDateTime { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "End DateTime is Required.")]
        [DataType(DataType.DateTime)]
        public System.DateTime EndDateTime { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Status is Required.")]
        public string Status { get; set; }

        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        
        [DataType(DataType.Text)]
        public string Note { get; set; }

        //public virtual Appointments Appointment { get; set; }
        //public virtual Mechanics Mechanic { get; set; }
    }
}
