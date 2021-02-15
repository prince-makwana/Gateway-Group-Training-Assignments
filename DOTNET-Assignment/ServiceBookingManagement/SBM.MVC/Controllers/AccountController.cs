using SBM.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Web.Security;
using System.Web.Configuration;

namespace SBM.MVC.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLogin model)
        {
            using (var client = new HttpClient())
            {
                var requestUri = "https://localhost:44318/api/Account/Login";

                //HTTP POST
                var postTask = client.PostAsJsonAsync<UserLogin>(requestUri, model);
                var result = postTask.Result;

                if (result.StatusCode == HttpStatusCode.OK)
                {
                    HttpCookie userInfo = new HttpCookie("userInfo");
                    int timeout = model.RememberMe ? 120 : 10; // 1440 min = 1 year
                    var ticket = new FormsAuthenticationTicket(model.EmailId, model.RememberMe, timeout);
                    string encrypted = FormsAuthentication.Encrypt(ticket);
                    var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                    cookie.Expires = DateTime.Now.AddMinutes(timeout);
                    Response.Cookies.Add(cookie);
                  
                    userInfo.Expires.AddMinutes(60);

                    #region If UserType is Customer
                    if (model.User == UserType.Customer)
                    {
                        ViewBag.Message = "Successfully Logged In.";
                        var user = GetCustomer(model.EmailId);

                        if (user != null)
                        {
                            #region Adding User Details into Cookie Info
                            userInfo["EmailId"] = user.EmailId;
                            userInfo["Name"] = user.CustomerName;
                            userInfo["userId"] = user.CustomerId.ToString();
                            Response.Cookies.Add(userInfo);
                            #endregion
                            return RedirectToAction("Dashboard", "Customer");
                            //return Redirect;
                        }
                        else
                        {
                            ViewBag.ErrorMessage = "Unable to Process Request. Please Contact Admin.";
                            return RedirectToAction("Index", "Account");
                        }
                        
                    }
                    #endregion
                    #region If UserType is Dealer
                    else
                    {
                        ViewBag.Message = "Successfully Logged In.";
                        var user = GetDealer(model.EmailId);
                        if(user != null)
                        {
                            #region Adding User Details into Cookie Info
                            userInfo["EmailId"] = user.EmailId;
                            userInfo["Name"] = user.DealerName;
                            userInfo["userId"] = user.DealerId.ToString();
                            Response.Cookies.Add(userInfo);
                            #endregion
                            return RedirectToAction("Dashboard", "Dealer");
                        }
                        else
                        {
                            ViewBag.ErrorMessage = "Unable to Process Request. Please Contact Admin.";
                            return RedirectToAction("Index", "Account");
                        }
                    }
                    #endregion
                }
                else
                {
                    ViewBag.Message = "Enter Correct Credentials.";
                    return RedirectToAction("Index", "Account");
                }
            }
        }

        [Authorize]
        public ActionResult Logout()
        {
            HttpCookie cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            cookie1.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie1);

            HttpCookie cookie2 = new HttpCookie("userInfo");
            cookie2.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie2);

            SessionStateSection sessionStateSection = (SessionStateSection)WebConfigurationManager.GetSection("system.web/sessionState");
            HttpCookie cookie3 = new HttpCookie(sessionStateSection.CookieName, "");
            cookie3.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie3);

            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Account");
        }

        [NonAction]
        public Customers GetCustomer(string emailId)
        {
            using(var client = new HttpClient())
            {
                var requestUri = "https://localhost:44318/Customer/GetCustomerInfo?emailId="+emailId;

                Customers data = new Customers();
                var responseTask = client.GetAsync(requestUri).Result;
                if(responseTask.IsSuccessStatusCode)
                {
                    var readTask = responseTask.Content.ReadAsAsync<Customers>();
                    data = readTask.Result;
                }
                else
                {
                    data = null;
                }
                return data;
            }
        }

        public Dealers GetDealer(string emailId)
        {
            using (var client = new HttpClient())
            {
                var requestUri = "https://localhost:44318/Dealer/GetDealerInfo?emailId=" + emailId;

                Dealers data = new Dealers();
                var responseTask = client.GetAsync(requestUri).Result;
                if (responseTask.IsSuccessStatusCode)
                {
                    var readTask = responseTask.Content.ReadAsAsync<Dealers>();
                    data = readTask.Result;
                }
                else
                {
                    data = null;
                }
                return data;
            }
        }
    }
}