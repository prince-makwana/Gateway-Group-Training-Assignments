using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBM.Models
{
    public class Appointments
    {
        public int AppintmentId { get; set; }
        public int ServiceId { get; set; }
        public int DealerId { get; set; }
        public int CustomerId { get; set; }
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
