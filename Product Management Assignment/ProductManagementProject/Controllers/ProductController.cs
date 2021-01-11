using ProductManagementProject.Context;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ProductManagementProject.Controllers
{
    public class ProductController : Controller
    {
        //IEnumerable<Product> productlist;
        ProductManagementEntities db = new ProductManagementEntities();
        // GET: Product
        [Authorize]
        public ActionResult ProductList()
        {
            IEnumerable<Product> products = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44372/api/");

                //HTTP GET
                var responseTask = client.GetAsync("products");

                var result = responseTask.Result;
                if(result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IEnumerable<Product>>();

                    products = readTask.Result;
                }
                else
                {
                    products = Enumerable.Empty<Product>();

                    ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                }
            }
            return View(products);
        }

        [Authorize]
        public ActionResult AddProduct(Product model)
        {
            IEnumerable<Product> productList = null;

            if (ModelState.IsValid)
            {
                Product obj = new Product();
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

                if(model.ID == 0)
                {
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("https://localhost:44372/api/products");

                        //HTTP POST
                        var postTask = client.PostAsJsonAsync<Product>("Products", obj);
                        var result = postTask.Result;
                        if (result.IsSuccessStatusCode)
                        {
                            TempData["successMsg"] = "Saved Successfully";
                        }
                    }
                }
                else
                {
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("https://localhost:44372/api/products");

                        //HTTP POST
                        var postTask = client.PostAsJsonAsync<Product>("Products/"+model.ID, obj);
                        var result = postTask.Result;
                        if (result.IsSuccessStatusCode)
                        {
                            TempData["successMsg"] = "Updated Successfully";
                        }
                    }
                }

                using(var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44372/api/");
                    var response = client.GetAsync("products").Result;
                    productList = response.Content.ReadAsAsync<IEnumerable<Product>>().Result;
                }
            }
            return View("ProductList", productList);
        }

        [Authorize]
        public ActionResult DeleteProduct(int id)
        {
            IEnumerable<Product> productList;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44372/api/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("products/" + id.ToString());
                var result = deleteTask.Result;

                var response = client.GetAsync("products").Result;
                productList = response.Content.ReadAsAsync<IEnumerable<Product>>().Result;
                TempData["successMsg"] = "Deleted Successfully";
                if(result.IsSuccessStatusCode)
                {
                    return View("ProductList", productList);
                }
            }
            return View("ProductList", productList);
        }

        [Authorize]
        [HttpGet]
        public ActionResult ProductPage(Product product)
        {
            if(product!=null)
            {
                return View(product);
            }
            else
            {
                return View();
            }
        }
    }
}