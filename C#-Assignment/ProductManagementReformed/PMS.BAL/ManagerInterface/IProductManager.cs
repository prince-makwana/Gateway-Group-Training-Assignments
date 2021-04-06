using PMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.BAL.ManagerInterface
{
    public interface IProductManager
    {
        bool DeleteProduct(int id);
        bool EditProduct(ProductVM product);
        ProductVM GetProductById(int id);
        bool AddProduct(ProductVM product);
        List<ProductVM> GetAllProducts();
    }
}
