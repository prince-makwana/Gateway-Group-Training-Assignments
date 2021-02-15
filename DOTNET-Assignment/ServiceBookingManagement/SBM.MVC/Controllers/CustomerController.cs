using SBM.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace SBM.MVC.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Register()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Customers model)
        {
            model.CreatedBy = model.CustomerName;
            model.CreatedDate = DateTime.Now;

            using (var client = new HttpClient())
            {
                var requestUri = "https://localhost:44318/api/Customer/RegisterCustomer";

                //HTTP POST
                var postTask = client.PostAsJsonAsync<Customers>(requestUri, model);
                var result = postTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError(string.Empty, "Server Error. Please Contact Admin.");
            return RedirectToAction("Register", "Customer");
        }

        [Authorize]
        public ActionResult Dashboard(Customers user)
        {
            return View(user);
        }
    }
}