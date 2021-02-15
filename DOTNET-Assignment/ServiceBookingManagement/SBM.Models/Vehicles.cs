using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBM.Models
{
    public class Vehicles
    {
        public int VehicleId { get; set; }
        public string LicensePlate { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public System.DateTime RegistrationDate { get; set; }
        public string ChassisNo { get; set; }
        public string Colour { get; set; }
        public double MeterValue { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public int CustomerId { get; set; }

        //public virtual Customers Customer { get; set; }
    }
}
