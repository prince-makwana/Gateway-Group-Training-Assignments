using PMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.DAL.RepositoryInterface
{
    public interface IProductRepository
    {
        bool DeleteProduct(int id);
        bool EditProduct(ProductVM product);
        ProductVM GetProductById(int id);
        bool AddProduct(ProductVM product);
        List<ProductVM> GetAllProducts();
    }
}
