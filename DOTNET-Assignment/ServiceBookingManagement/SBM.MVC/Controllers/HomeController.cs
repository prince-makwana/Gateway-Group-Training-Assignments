using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SBM.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}

//public class CustomerController : Controller
//{
//    // GET: Customer
//    [HttpGet]
//    public ActionResult RegisterUser()
//    {
//        return View();
//    }

//    [HttpPost]
//    public ActionResult RegisterUser(Customers model)
//    {
//        using (var client = new HttpClient())
//        {
//            var requestUri = "https://localhost:44318/api/Customer/RegisterCustomer";

//            //HTTP POST
//            var postTask = client.PostAsJsonAsync<Customers>(requestUri, model);
//            var result = postTask.Result;

//            if (result.IsSuccessStatusCode)
//            {
//                return RedirectToAction("Index", "Home");
//            }
//        }
//        ModelState.AddModelError(string.Empty, "Server Error. Please Contact Admin.");
//        return RedirectToAction("RegisterUser", "Customer");
//    }
//}