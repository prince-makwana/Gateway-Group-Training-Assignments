using NUnit.Framework;
using ProductConsoleApp.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductAppTest
{
    [TestFixture]
    public class ProductRepositoryTest
    {
        private ProductRepository _productRepository;

        [SetUp]
        public void Setup()
        {
            // Arrange
            _productRepository = new ProductRepository();
        }

        // Fluent Assertion

        //Test for records haing Category Electronics
        [Test]
        public void GetProducts_Test_CategoryIsElectronics()
        {
            // Act
            var result = _productRepository.GetProducts();

            // Assert
            Assert.That(result, 
                Has.Count.EqualTo(5).
                And.Exactly(2).Property("Category").EqualTo("Electronics"));
        }

        // Test For Electronics Product Price is Greater Than 1300
        [Test]
        public void GetProducts_Test_CategoryIsElectronicsAndPriceIsGR1300()
        {
            // Act
            var result = _productRepository.GetProducts();

            // Assert
            Assert.That(result,
                Has.Count.EqualTo(5).
                And.Exactly(1).Property("Category").EqualTo("Electronics")
                .And.Property("Price").GreaterThan(1300F));
        }

        // Test for Products Price Less Than 1000
        [Test]
        public void GetProducts_Test_PriceIsLT1000()
        {
            // Act
            var result = _productRepository.GetProducts();

            // Assert
            Assert.That(result,
                Has.Count.EqualTo(5)
                .And.Exactly(1).Property("Price").LessThanOrEqualTo(1000F));
        }

        //// Test for Products Reviews Greater Than 1.0
        //[Test]
        //public void GetProducts_Test_
    }
}
