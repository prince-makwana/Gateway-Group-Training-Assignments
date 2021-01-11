using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductManagementProject.Context;
using ProductManagementProject.Controllers;

namespace ProductManagement.Tests
{
    class ProductControllerTests
    {
        [TestMethod]
        public void Index()
        {
            //Arrange

            UserController controller = new UserController();

            //Act
            ViewResult result = controller.RegisterUser() as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ProductLists()
        {
            ProductManagementEntities db = new ProductManagementEntities();

            //Act

            var result = db.Products.ToList();

            //Assert
            Assert.IsNotNull(result);
        }
    }
}
