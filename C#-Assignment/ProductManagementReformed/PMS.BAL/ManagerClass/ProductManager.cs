using PMS.BAL.ManagerInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.DAL.RepositoryInterface;
using PMS.Model;

namespace PMS.BAL.ManagerClass
{
    public class ProductManager : IProductManager
    {
        private readonly IProductRepository _productRepository;

        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public string AddProduct(Product model)
        {
           return _productRepository.AddProduct(model);
        }

        public string DeletProduct(int id)
        {
            return _productRepository.DeletProduct(id);
        }

        public List<Product> GetProducts(int userId)
        {
            return _productRepository.GetProducts(userId);
        }

        public string UpdateProduct(Product model)
        {
            return _productRepository.UpdateProduct(model);
        }
    }
}
