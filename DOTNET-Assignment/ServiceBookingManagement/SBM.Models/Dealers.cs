using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBM.Models
{
    public class Dealers
    {
        public int DealerId { get; set; }
        public string DealerName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string ZipCode { get; set; }
        public string ContactNo { get; set; }
        public string EmailId { get; set; }
        public bool IsActive { get; set; }
        public string Password { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        //public virtual Appointments Appointment { get; set; }
        //public virtual Mechanics Mechanic { get; set; }
        //public virtual Services Service { get; set; }
    }
}
