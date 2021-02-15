using PMS.MVC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;

namespace PMS.MVC.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        [Authorize]
        public ActionResult ProductPage()
        {
            return View();
        }

        [Authorize]
        public ActionResult ProductList()
        {
            IEnumerable<Product> products = null;
            using (var client = new HttpClient())
            {
                string getUri = "https://localhost:44357/GetAllProducts/" + (int)Session["UserId"];

                //HTTP GET
                var responseTask = client.GetAsync(getUri);

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadFromJsonAsync<IEnumerable<Product>>();

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
        [ValidateAntiForgeryToken]
        public ActionResult AddProduct(Product model)
        {
            //IEnumerable<Product> productList = null;


            if (!ModelState.IsValid)
            {
                var fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                var fileExtension = Path.GetExtension(model.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + fileExtension;
                model.SmallImage = "~/Images/" + fileName;
                model.LongImage = "~/Images/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
                model.ImageFile.SaveAs(fileName);

                model.UserId = (int)Session["UserId"];

                if (model.ProductId == 0)
                {
                    // POST Product Data

                    #region POST Product Data

                    using (var client = new HttpClient())
                    {
                        string postUri = "https://localhost:44357/AddProduct/";
                        //var postTask = client.PostAsJsonAsync<Product>(postUri, model);
                        var postTask = client.PostAsJsonAsync<Product>(postUri, model);
                        postTask.Wait();
                        var result = postTask.Result;

                        if (result.IsSuccessStatusCode)
                        {
                            TempData["Message"] = result.Content.ReadAsStringAsync().ToString();
                        }
                    }

                    #endregion
                }
                else
                {
                    // PUT Product Data
                    #region PUT Product Data

                    using (var client = new HttpClient())
                    {
                        string postUri = "https://localhost:44357/UpdateProduct";
                        var postTask = client.PostAsJsonAsync<Product>(postUri, model);
                        postTask.Wait();

                        var result = postTask.Result;

                        if (result.IsSuccessStatusCode)
                        {
                            TempData["Message"] = result.Content.ReadAsStringAsync().ToString();
                            
                        }
                    }

                    #endregion
                }

                //using (var client = new HttpClient())
                //{
                //    string getUri = "https://localhost:44372/GetAllProducts/" + (int)Session["UserId"];

                //    //HTTP GET
                //    var responseTask = client.GetAsync(getUri);

                //    var result = responseTask.Result;
                //    if (result.IsSuccessStatusCode)
                //    {
                //        var readTask = result.Content.ReadFromJsonAsync<IEnumerable<Product>>();

                //        productList = readTask.Result;
                //    }

                //}
            }
            return RedirectToAction("ProductList", "Products");
        }
    }
}