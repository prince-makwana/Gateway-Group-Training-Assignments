using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBM.MVC.Models
{
    public class Services
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public int DealerId { get; set; }
        public double Price { get; set; }
        public double FixPrice { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }

        //public virtual ICollection<Appointments> Appointments { get; set; }
        //public virtual Dealers Dealer { get; set; }
    }
}
