using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBM.Models
{
    public class JobCards
    {
        public int JobCardId { get; set; }
        public int MechanicId { get; set; }
        public int AppointmentId { get; set; }
        public double TotalPrice { get; set; }
        public System.DateTime StartDateTime { get; set; }
        public System.DateTime EndDateTime { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public string Note { get; set; }

        //public virtual Appointments Appointment { get; set; }
        //public virtual Mechanics Mechanic { get; set; }
    }
}
