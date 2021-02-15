using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PMS.MVC.Model
{
    public class Product
    {
        public int ProductId { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is Required.")]
        public string Name { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Category is Required.")]
        public string Category { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Price is Required.")]
        public double Price { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Quantity is Required.")]
        public int Quantity { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Short Description is Required.")]
        public string ShortDescription { get; set; }
        
        public string LongDescription { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Small Image is Required.")]
        public string SmallImage { get; set; }
        
        public string LongImage { get; set; }
        
        public int UserId { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }

        //public virtual tblUser tblUser { get; set; }
    }
}
