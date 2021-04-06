using PMS.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PMS.MVC.Controllers
{
    public class ProductController : Controller
    {
        /// <summary>
        /// Display Product List
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public ActionResult ProductList()
        {
            IEnumerable<ProductVM> products = null;

            using (var client = new HttpClient())
            {
                string getUri = "https://localhost:44376/ProductList";

                //HTTP GET
                var responseTask = client.GetAsync(getUri);

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IEnumerable<ProductVM>>();

                    products = readTask.Result;
                }
                else
                {
                    products = Enumerable.Empty<ProductVM>();

                    ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                }
            }
            ViewBag.Message = TempData["Message"];
            return View(products);
        }

        /// <summary>
        /// Add Product POST method
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddProduct(ProductVM model)
        {
            IEnumerable<ProductVM> productList = null;

            if (ModelState.IsValid)
            {
                ProductVM obj = new ProductVM();
                obj.ID = model.ID;
                obj.Name = model.Name;
                obj.Category = model.Category;

                obj.Price = model.Price;

                var fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                var fileExtension = Path.GetExtension(model.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + fileExtension;
                model.smallImage = "~/Images/" + fileName;
                model.longImage = "~/Images/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
                model.ImageFile.SaveAs(fileName);
                obj.smallImage = model.smallImage;
                obj.longImage = model.longImage;

                obj.shortDescription = model.shortDescription;
                obj.longDescription = model.longDescription;
                obj.Quantity = model.Quantity;

                
                using (var client = new HttpClient())
                {
                    string postUri = "https://localhost:44376/AddProduct";

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<ProductVM>(postUri, obj);
                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        TempData["Message"] = "Added Successfully";
                        return RedirectToAction("ProductList", "Product");
                    }
                }
                //using (var client = new HttpClient())
                //{
                //    string getUri = "https://localhost:44376/ProductList";
                //    var response = client.GetAsync(getUri).Result;
                //    productList = response.Content.ReadAsAsync<IEnumerable<ProductVM>>().Result;
                //}
            }
            TempData["Message"] = "Model State not valid!";
            return RedirectToAction("ProductList", "Product");
        }

        /// <summary>
        /// Delete Product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        public ActionResult DeleteProduct(int id)
        {
            IEnumerable<ProductVM> productList;
            using (var client = new HttpClient())
            {
                string deleteUri = "https://localhost:44376/DeleteProduct/"+id;

                var getProduct = GetProductId(id);
                string path = Server.MapPath(getProduct.smallImage);
                FileInfo file = new FileInfo(path);
                if (file.Exists)
                {
                    file.Delete();
                    GC.SuppressFinalize(getProduct);
                }

                //HTTP DELETE
                var deleteTask = client.DeleteAsync(deleteUri);
                var result = deleteTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    TempData["Message"] = "Deleted Successfully!";
                    return RedirectToAction("ProductList", "Product");
                }
            }
            TempData["Message"] = "Internal Server Error. Try after sometime!";
            return RedirectToAction("ProductList", "Product");
        }

        /// <summary>
        /// Add Product Page GET method
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public ActionResult ProductPage(ProductVM product)
        {
            if (product != null)
            {
                return View(product);
            }
            else
            {
                return View();
            }
        }

        /// <summary>
        /// Edit product GET method
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public ActionResult EditProduct(int? id)
        {
            if(id == null)
            {
                TempData["Message"] = "Product not exists!";
                return RedirectToAction("ProductList", "Product");
            }

            var product = GetProductId(id);

            if(product == null)
            {
                TempData["Message"] = "Internal Server Error!";
                return RedirectToAction("ProductList", "Product");
            }
            return View(product);
        }

        /// <summary>
        /// Edit product POST method
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProduct(ProductVM model)
        {
            if (ModelState.IsValid)
            {
                ProductVM obj = new ProductVM();
                obj.ID = model.ID;
                obj.Name = model.Name;
                obj.Category = model.Category;

                obj.Price = model.Price;

                var fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                var fileExtension = Path.GetExtension(model.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + fileExtension;
                model.smallImage = "~/Images/" + fileName;
                model.longImage = "~/Images/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
                model.ImageFile.SaveAs(fileName);
                obj.smallImage = model.smallImage;
                obj.longImage = model.longImage;

                obj.shortDescription = model.shortDescription;
                obj.longDescription = model.longDescription;
                obj.Quantity = model.Quantity;

                using (var client = new HttpClient())
                {
                    string putUri = "https://localhost:44376/EditProduct";

                    //HTTP POST
                    var postTask = client.PutAsJsonAsync<ProductVM>(putUri, obj);
                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        TempData["Message"] = "Updated Successfully";
                        return RedirectToAction("ProductList", "Product");
                    }
                }
            }
            return RedirectToAction("ProductList", "Product");
        }

        /// <summary>
        /// Get Product By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [NonAction]
        public ProductVM GetProductId(int? id)
        {
            ProductVM product = null;
            
            using (var client = new HttpClient())
            {
                string getUri = "https://localhost:44376/GetProductById/" + id;

                //HTTP GET
                var responseTask = client.GetAsync(getUri);

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ProductVM>();

                    product = readTask.Result;
                }
                else
                {
                    product = null;

                    ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                }
            }

            
            return product;
        }
    }
}