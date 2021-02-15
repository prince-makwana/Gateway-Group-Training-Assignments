using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string SmallImage { get; set; }
        public string LongImage { get; set; }
        public int UserId { get; set; }

        //public virtual tblUser tblUser { get; set; }
    }
}
