using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBM.MVC.Models
{
    public class Records
    {
        public long RecordId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Customer Name is Required.")]
        public string CustomerName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Dealer Name is Required.")]
        public string DealerName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Dealer Contact No is Required.")]
        public string DealerContactNo { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Mechanic Name is Required.")]
        public string MechanicName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Mechanic Contact No is Required.")]
        public string MechanicContactNo { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Service Name is Required.")]
        public string ServiceName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Start DateTime is Required.")]
        [DataType(DataType.DateTime)]
        public System.DateTime StartDateTime { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "End DateTime is Required.")]
        [DataType(DataType.DateTime)]
        public System.DateTime EndDateTime { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Total Price is Required.")]
        public double TotalPrice { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "License Plate is Required.")]
        public string LicensePlate { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Dealer Id is Required.")]
        public int DealerId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Customer Id is Required.")]
        public int CustomerId { get; set; }
        
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
    }
}
