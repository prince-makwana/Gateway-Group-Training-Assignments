using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBM.MVC.Models
{
    public class Vehicles
    {
        public int VehicleId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "LicencePlate is Required.")]
        public string LicensePlate { get; set; }

        public string Make { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Model is Required.")]
        public string Model { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Registration Date is Required.")]
        [DataType(DataType.Date)]
        public System.DateTime RegistrationDate { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Chassis No is Required.")]
        public string ChassisNo { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Colour is Required.")]
        public string Colour { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "MeterValue is Required.")]
        public double MeterValue { get; set; }

        public string Description { get; set; }
        
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Customer ID is Required.")]
        public int CustomerId { get; set; }

        //public virtual Customers Customer { get; set; }
    }
}
