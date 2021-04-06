using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PMS.Models
{
    public class ProductVM
    {
        public long ID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Product Name is Required")]
        public string Name { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Category is Required")]
        public string Category { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Price is Required")]
        public Nullable<long> Price { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Quantity is Required")]
        public Nullable<long> Quantity { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Description is Required")]
        public string shortDescription { get; set; }

        public string longDescription { get; set; }

        public string smallImage { get; set; }

        public string longImage { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }
    }
}
