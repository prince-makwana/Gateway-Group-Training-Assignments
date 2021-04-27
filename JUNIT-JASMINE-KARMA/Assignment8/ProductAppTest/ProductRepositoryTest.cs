using NUnit.Framework;
using ProductAppTest.CustomAttribute;
using ProductAppTest.Utilities;
using ProductConsoleApp.Models;
using ProductConsoleApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        // Test for Products Reviews Greater Than 1.0
        [Test]
        public void GetProducts_Test_ReviewsIsGT1()
        {
            // Act
            var result = _productRepository.GetProducts();

            // Assert
            Assert.That(result,
                Has.Count.EqualTo(5)
                .And.Exactly(4).Property("Reviews").GreaterThan(1.0F));
        }

        // Test for Products Reviews Equal to 5.0 and Price Greater Than 5000F
        [Test]
        public void GetProducts_Test_ReviewsIsGT5_PriceIsGT5000()
        {
            // Act
            var result = _productRepository.GetProducts();

            // Assert
            Assert.That(result,
                Has.Count.EqualTo(5)
                .And.Exactly(0).Property("Reviews").EqualTo(5.0F)
                .And.Property("Price").GreaterThan(5000F));
        }

        // Sequential Execution

        [TestOrder(2)]
        public void Test1InputProduct()
        {
            // Act
            var result = new ProductRepository().GetProducts();
            result.Add(new Product { Id = 6, Name = "Bajaj Microwave Oven", Category = "Kitchen and Home Appliances", Price = 6000.0F, Reviews = 4.9F });

            // Assert
            Assert.That(result,
                Has.Count.EqualTo(6)
                .And.Exactly(1).Property("Name").Contains("Oven"));
        }

        [TestOrder(1)]
        public void Test2SelectProducts()
        {
            // Act
            var result = new ProductRepository().GetProducts();

            // Assert
            Assert.That(result,
                Has.Count.EqualTo(5));
        }

        [TestOrder(4)]
        public void Test3UpdateProduct()
        {
            // Act
            var result = new ProductRepository().GetProducts().Where(p => p.Id == 1).FirstOrDefault();
            result.Name = "HP Pavilion x360 Touchscreen Laptop";
            // Assert
            Assert.That(result,
                Has.Property("Name").EqualTo("HP Pavilion x360 Touchscreen Laptop"));
        }

        [TestOrder(3)]
        public void Test4DeleteProduct()
        {
            // Act
            var result = new ProductRepository().GetProducts().Remove
                (
                    new ProductRepository().GetProducts()
                    .Where(p => p.Id == 1).FirstOrDefault()
                );

            // Assert
            Assert.AreEqual(result, false);
        }

        [TestOrder(5)]
        public void Test5RemoveAllProducts()
        {
            // Act
            var result = new ProductRepository().GetProducts().RemoveAll(p => p.Price >= 0F);

            // Assert
            Assert.AreEqual(result, 5);
        }

        [TestCaseSource(sourceName: "TestSource")]
        public void MyTest(TestStructure test)
        {
            test.Test();
        }

        public static IEnumerable<TestCaseData> TestSource
        {
            get
            {
                var assembly = Assembly.GetExecutingAssembly();
                Dictionary<int, List<MethodInfo>> methods = assembly
                    .GetTypes()
                    .SelectMany(p => p.GetMethods())
                    .Where(p => p.GetCustomAttributes().OfType<TestOrderAttribute>().Any())
                    .GroupBy(p => p.GetCustomAttribute<TestOrderAttribute>().Sequence)
                    .ToDictionary(p => p.Key, p => p.ToList());

                foreach (var order in methods.Keys.OrderBy(p => p))
                {
                    foreach (var methodInfo in methods[order])
                    {
                        MethodInfo info = methodInfo;
                        yield return new TestCaseData(
                            new TestStructure
                            {
                                Test = () =>
                                {
                                    object classInstance = Activator.CreateInstance(info.DeclaringType, null);
                                    info.Invoke(classInstance, null);
                                }
                            }).SetName(methodInfo.Name);
                    }
                }
            }
        }
    }
}
