using PMS.DAL.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.Model;
using AutoMapper;

namespace PMS.DAL.RepositoryClass
{
    public class ProductRepository : IProductRepository
    {
        private readonly Database.ProductManagmentEntities _dbContext;

        public ProductRepository()
        {
            _dbContext = new Database.ProductManagmentEntities();
        }

        /// <summary>
        /// This method gets all products in list which was entered by user.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<Product> GetProducts(int userId)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Database.tblProduct, Product>());
            var mapper = config.CreateMapper();

            List<Product> productList = new List<Product>();

            var data = _dbContext.tblProducts.Where(p => p.UserId == userId).ToList();

            if (data != null)
            {
                foreach (var item in data)
                {
                    Product product = mapper.Map<Product>(item);
                    productList.Add(product);
                }
            }
            return productList;
        }

        /// <summary>
        /// Method to add Product by user.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string AddProduct(Product model)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Product, Database.tblProduct>());
            var mapper = config.CreateMapper();

            var product = mapper.Map<Database.tblProduct>(model);

            _dbContext.tblProducts.Add(product);
            _dbContext.SaveChanges();

            return "Product Addedd Successfully.";
        }

        /// <summary>
        /// Method to Update Product.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string UpdateProduct(Product model)
        {
            var entity = _dbContext.tblProducts.Find(model.ProductId);
            if(entity != null)
            {
                entity.Name = model.Name;
                entity.Category = model.Category;
                entity.Price = model.Price;
                entity.Quantity = model.Quantity;
                entity.ShortDescription = model.ShortDescription;
                entity.LongDescription = model.LongDescription;
                entity.SmallImage = model.SmallImage;
                entity.LongImage = model.LongImage;

                _dbContext.SaveChanges();
                return "Product Updated Successfully!";
            }
            else
            {
                return "Something went wrong. Please try after sometime.";
            }
        }

        /// <summary>
        /// Method to Delete Product.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string DeletProduct(int id)
        {
            if (id <= 0)
                return "Not a valid Product.";
            else
            {
                var product = _dbContext.tblProducts.Find(id);
                
                if(product == null)
                {
                    return "Something went wrong or Product not Found...Contact Admin....";
                }
                else
                {
                    _dbContext.Entry(product).State = System.Data.Entity.EntityState.Deleted;
                    _dbContext.SaveChanges();

                    return "Deleted Successfully.";
                }
            }
        }
    }
}
