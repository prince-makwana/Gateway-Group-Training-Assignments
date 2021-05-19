using Assignment9.Models;
using Assignment9.Repository;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Assignment9.Tests
{
    public class ProductTests
    {
        private ProductRepository _productRepository;

        [SetUp]
        public void Setup()
        {
            //Creation of Mock object
            var productRepositoryMock = new Mock<ProductRepository>();

            productRepositoryMock.Setup(p => p.GetProducts()).Returns(
                new List<Product>()
                {
                    new Product{Id=1, Name="HP Pavilion Laptop", Category="Electronics", Price=90934.90F, Reviews=3.2F},
                    new Product{Id=2, Name="Boult Bassbuds Earphone X2", Category="Electronics", Price=1200.00F, Reviews=5.0F},
                    new Product{Id=3, Name="The Canterville Ghost", Category="Book", Price=120F, Reviews=5.0F},
                    new Product{Id=4, Name="Bajaj Grinder", Category="Kitchen and Home Appliances", Price=3500F, Reviews=4.5F},
                    new Product{Id=5, Name="Amway Organic Beauty Kit", Category="Skin Care", Price=2000F, Reviews=1.0F}
                });
            _productRepository = productRepositoryMock.Object;
        }

        // Test cases using Mock

        [Test]
        public void Product_Count_Test_Positive()
        {
            //Assert
            Assert.True(_productRepository.GetProducts().Count == 5);
        }

        [Test]
        public void Product_Count_Test_Negative()
        {
            //Assert
            Assert.False(_productRepository.GetProducts().Count == 3);
        }

        [Test]
        public void Product_Category_By_Id()
        {
            //Arrange
            var result = _productRepository.GetProducts().Where(p => p.Id == 1).FirstOrDefault();
            //Assert
            Assert.AreEqual("Electronics", result.Category);
        }

        [Test]
        public void Product_Category_By_Id_Test_Negative()
        {
            //Arrange
            var result = _productRepository.GetProducts().Where(p => p.Id == 1).FirstOrDefault();
            //Assert
            Assert.AreNotEqual("Book", result.Category);
        }

        [Test]
        public void Product_Price_GT_2000()
        {
            //Arrange
            var result = _productRepository.GetProducts().Where(p => p.Price > 2000).ToList();
            //Assert
            Assert.AreEqual(2, result.Count);
        }

        [Test]
        public void Product_Price_GT_2000_Test_Negative()
        {
            //Arrange
            var result = _productRepository.GetProducts().Where(p => p.Price > 2000).ToList();
            //Assert
            Assert.AreNotEqual(5, result.Count);
        }

        [Test]
        public void Product_Price_GT_2000_Category()
        {
            //Arrange
            var result = _productRepository.GetProducts().Where(p => p.Price == 1000 && p.Category == "Electronics").ToList();
            //Assert
            Assert.AreEqual(0, result.Count);
        }

        [Test]
        public void Product_Price_GT_2000_Category_Test_Negative()
        {
            //Arrange
            var result = _productRepository.GetProducts().Where(p => p.Price == 1000 && p.Category == "Electronics").ToList();
            //Assert
            Assert.AreNotEqual(3, result.Count);
        }

    }
}