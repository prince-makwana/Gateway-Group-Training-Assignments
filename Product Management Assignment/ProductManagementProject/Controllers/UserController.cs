using ProductManagementProject.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ProductManagementProject.Controllers
{
    public class UserController : Controller
    {
        private ProductManagementEntities db = new ProductManagementEntities();
        // GET: User
        public ActionResult RegisterUser()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterUser(User user)
        {
            #region Email is already Exist
            var isExist = IsEmailExist(user.Email);
            if (isExist)
            {
                ModelState.AddModelError("EmailExist", "Email already exist");
                TempData["errorMsg"] = "Email already exist";
                return View(user);
            }
            #endregion

            #region Password Hashing
            user.Password = Crypto.Hash(user.Password);
            #endregion

            //var response = GlobalVariables.WebApiClient.PostAsJsonAsync<User>("Users", user);
            ////response.Wait();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44372/api/users");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<User>("Users", user);
                var result = postTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    TempData["successMsg"] = "Registration Successfully";
                    return RedirectToAction("Login", "User");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please Contact administrator.");
            TempData["errorMsg"] = "Registration Failed";
            return RedirectToAction("RegisterUser", "User", new { are = "" });
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLogin login)
        {
            var v = db.Users.Where(a => a.Email == login.EmailID).FirstOrDefault();
            if (v != null)
            {
                var passCompare = string.Compare(Crypto.Hash(login.Password), v.Password);
                if (passCompare == 0)
                {
                    int timeout = login.RememberMe ? 1440 : 60; // 1440 min = 1 year
                    var ticket = new FormsAuthenticationTicket(login.EmailID, login.RememberMe, timeout);
                    string encrypted = FormsAuthentication.Encrypt(ticket);
                    var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                    cookie.Expires = DateTime.Now.AddMinutes(timeout);
                    cookie.HttpOnly = true;
                    Response.Cookies.Add(cookie);

                    if (v != null)
                    {
                        Session["Username"] = v.Name;
                        return View("Dashboard", v);
                    }
                }
            }
            return View();
        }

        [Authorize]
        public ActionResult Dashboard(User user)
        {
            return View(user);
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "User");
        }

        [NonAction]
        public bool IsEmailExist(string emailID)
        {
            var v = db.Users.Where(a => a.Email == emailID).FirstOrDefault();
            return v != null;
        }
    }
}