using SBM.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace SBM.MVC.Controllers
{
    public class DealerController : Controller
    {
        // GET: Dealer

        #region Dealer Registration
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Dealers model)
        {
            model.CreatedBy = model.DealerName;
            model.CreatedDate = DateTime.Now;

            using (var client = new HttpClient())
            {
                var requestUri = "https://localhost:44318/api/Dealer/RegisterDealer";

                //HTTP POST
                var postTask = client.PostAsJsonAsync<Dealers>(requestUri, model);
                var result = postTask.Result;

                ViewBag.Message = result.ToString();

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Dashboard", "Dealer");
                }
            }
            ModelState.AddModelError(string.Empty, "Server Error. Please Contact Admin.");
            return RedirectToAction("Register", "Dealer");
        }
        #endregion        

        #region Dealer Dashboard
        [Authorize]
        public ActionResult Dashboard(Dealers user)
        {
            return View(user);
        }
        #endregion

        #region Add Customers

        [HttpGet]
        [Authorize]
        public ActionResult AddCustomers()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCustomers(Customers model)
        {
            HttpCookie reqCookie = Request.Cookies["userInfo"];
            string Name = reqCookie["Name"].ToString();
            model.CreatedBy = Name;
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
        #endregion

        #region Add Vehicles

        [HttpGet]
        [Authorize]
        public ActionResult AddVehicle()
        {
            return View();
        }
        #endregion

        #region Appointments
        [Authorize]
        public ActionResult Appointment()
        {
            return View();
        }
        #endregion

        #region Reports
        [Authorize]
        public ActionResult Report()
        {
            return View();
        }
        #endregion
    }
}