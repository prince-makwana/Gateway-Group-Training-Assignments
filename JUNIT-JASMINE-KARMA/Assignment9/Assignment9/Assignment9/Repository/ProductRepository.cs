using Assignment9.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment9.Repository
{
    public class ProductRepository
    {
        List<Product> products = new List<Product>()
        {
            new Product{Id=1, Name="HP Pavilion Laptop", Category="Electronics", Price=90934.90F, Reviews=3.2F},
            new Product{Id=2, Name="Boult Bassbuds Earphone X2", Category="Electronics", Price=1200.00F, Reviews=5.0F},
            new Product{Id=3, Name="The Canterville Ghost", Category="Book", Price=120F, Reviews=5.0F},
            new Product{Id=4, Name="Bajaj Grinder", Category="Kitchen and Home Appliances", Price=3500F, Reviews=4.5F},
            new Product{Id=5, Name="Amway Organic Beauty Kit", Category="Skin Care", Price=2000F, Reviews=1.0F}
        };

        public virtual List<Product> GetProducts()
        {
            return products;
        }

        public virtual Product GetProductById(int id)
        {
            return products.Where(p => p.Id == id).FirstOrDefault();
        }
    }
}
