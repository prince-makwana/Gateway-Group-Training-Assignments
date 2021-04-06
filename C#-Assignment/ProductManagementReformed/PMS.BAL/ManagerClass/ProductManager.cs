using PMS.BAL.ManagerInterface;
using PMS.DAL.RepositoryInterface;
using PMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.BAL.ManagerClass
{
    public class ProductManager : IProductManager
    {
        private readonly IProductRepository _productrepository;

        public ProductManager(IProductRepository productRepository)
        {
            _productrepository = productRepository;
        }

        public bool AddProduct(ProductVM product)
        {
            return _productrepository.AddProduct(product);
        }

        public bool DeleteProduct(int id)
        {
            return _productrepository.DeleteProduct(id);
        }

        public bool EditProduct(ProductVM product)
        {
            return _productrepository.EditProduct(product);
        }

        public List<ProductVM> GetAllProducts()
        {
            return _productrepository.GetAllProducts();
        }

        public ProductVM GetProductById(int id)
        {
            return _productrepository.GetProductById(id);
        }
    }
}
