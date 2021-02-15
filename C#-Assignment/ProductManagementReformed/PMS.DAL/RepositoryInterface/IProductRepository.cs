using PMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.DAL.RepositoryInterface
{
    public interface IProductRepository
    {
        string DeletProduct(int id);
        string UpdateProduct(Product model);
        string AddProduct(Product model);
        List<Product> GetProducts(int userId);
    }
}
