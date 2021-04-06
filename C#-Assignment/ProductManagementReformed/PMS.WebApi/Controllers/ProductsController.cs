using PMS.BAL.ManagerInterface;
using PMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PMS.WebAPI.Controllers
{
    public class ProductsController : ApiController
    {
        private readonly IProductManager _productManager;

        public ProductsController(IProductManager productManager)
        {
            _productManager = productManager;
        }

        /// <summary>
        /// Returns All products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("ProductList")]
        public IHttpActionResult GetAllProducts()
        {
            var res = _productManager.GetAllProducts();
            if(res == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(res);
            }
        }

        /// <summary>
        /// Add Product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddProduct")]
        public IHttpActionResult AddProduct([FromBody]ProductVM product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model is not valid");
            }

            var res = _productManager.AddProduct(product);
            if (res)
            {
                return Ok("Added Successfully");
            }
            else
            {
                return BadRequest("Internal Server Error");
            }
        }

        /// <summary>
        /// Get Product By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetProductById/{id}")]
        public IHttpActionResult GetProductById(int id)
        {
            var product = _productManager.GetProductById(id);

            if(product != null)
            {
                return Ok(product);
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Edit Product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("EditProduct")]
        public IHttpActionResult EditProduct([FromBody]ProductVM product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model is not Valid");
            }

            var res = _productManager.EditProduct(product);
            if (res)
            {
                return Ok("Edited Successfully");
            }
            else
            {
                return BadRequest("Internal Server Error");
            }
        }

        /// <summary>
        /// Delete product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteProduct/{id}")]
        public IHttpActionResult DeleteProduct(int id)
        {
            var res = _productManager.DeleteProduct(id);
            if (res)
            {
                return Ok("Deleted Successfully!");
            }
            else
            {
                return BadRequest("Internal Server Error");
            }
        }
    }
}
