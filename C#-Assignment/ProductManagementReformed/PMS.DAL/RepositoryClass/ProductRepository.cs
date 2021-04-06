using AutoMapper;
using PMS.DAL.Database;
using PMS.DAL.RepositoryInterface;
using PMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.DAL.RepositoryClass
{
    public class ProductRepository : IProductRepository
    {
        private readonly Database.ProductManagementEntities _dbContext;

        public ProductRepository()
        {
            _dbContext = new Database.ProductManagementEntities();
        }

        public List<ProductVM> GetAllProducts()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductVM>());
            var mapper = new Mapper(config);

            List<ProductVM> productList = new List<ProductVM>();
            try
            {
                var entities = _dbContext.Products.ToList();

                if (entities == null)
                {
                    productList = null;
                }
                else
                {
                    foreach (var item in entities)
                    {
                        var product = mapper.Map<ProductVM>(item);
                        productList.Add(product);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return productList;
        }

        public bool AddProduct(ProductVM product)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ProductVM, Product>());
            var mapper = new Mapper(config);

            var newProduct = mapper.Map<Product>(product);

            try
            {
                _dbContext.Products.Add(newProduct);
                _dbContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public ProductVM GetProductById(int id)
        {
            ProductVM product = new ProductVM();
            try
            {
                product = GetAllProducts().FirstOrDefault(p => p.ID == id);
                if(product == null)
                {
                    product = null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return product;
        }

        public bool EditProduct(ProductVM product)
        {
            Product existingProduct = _dbContext.Products.SingleOrDefault(p => p.ID == product.ID);

            if (existingProduct != null)
            {
                #region Update Product MApping from ProductVM -----> Database.Product

                existingProduct.Name = product.Name;
                existingProduct.Quantity = product.Quantity;
                existingProduct.shortDescription = product.shortDescription;
                existingProduct.longDescription = product.longDescription;
                existingProduct.longImage = product.longImage;
                existingProduct.smallImage = product.smallImage;
                existingProduct.Price = product.Price;
                existingProduct.Category = product.Category;

                #endregion

                _dbContext.SaveChanges();

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteProduct(int id)
        {
            if (id < 0)
            {
                return false;
            }
            try
            {
                var product = _dbContext.Products.SingleOrDefault(p => p.ID == id);
                _dbContext.Products.Remove(product);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }
    }
}
