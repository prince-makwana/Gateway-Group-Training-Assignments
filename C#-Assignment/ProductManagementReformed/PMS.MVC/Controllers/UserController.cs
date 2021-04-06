using PMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PMS.MVC.Controllers
{
    public class UserController : Controller
    {
        // GET: Users
        public ActionResult RegisterUser()
        {
            ViewBag.Message = TempData["Message"];
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterUser(UserVM user)
        {
            #region Email is already Exist
            var isExist = IsEmailExist(user.Email);
            if (isExist)
            {
                ModelState.AddModelError("EmailExist", "Email already exist");
                TempData["Message"] = "Email already exists!";
                return RedirectToAction("RegisterUser", "User");
            }
            #endregion

            #region Password Hashing
            user.Password = Crypto.Hash(user.Password);
            #endregion

            //var response = GlobalVariables.WebApiClient.PostAsJsonAsync<User>("Users", user);
            ////response.Wait();

            using (var client = new HttpClient())
            {
                string postUri = "https://localhost:44376/RegisterUser";

                //HTTP POST
                var postTask = client.PostAsJsonAsync<UserVM>(postUri, user);
                var result = postTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    TempData["Message"] = "Registration done Successfully";
                    return RedirectToAction("Login", "User");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please Contact administrator.");
            TempData["Message"] = "Registration Failed";
            return RedirectToAction("RegisterUser", "User", new { are = "" });
        }

        [HttpGet]
        public ActionResult Login()
        {
            ViewBag.Message = TempData["Message"];
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(UserLogin login)
        {
            //var v = db.Users.Where(a => a.Email == login.EmailID).FirstOrDefault();
            UserVM v = new UserVM();

            using(var client = new HttpClient())
            {
                string postUri = "https://localhost:44376/UserLogin";

                login.Password = Crypto.Hash(login.Password);

                var postTask = client.PostAsJsonAsync<UserLogin>(postUri, login);
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    v = await result.Content.ReadAsAsync<UserVM>();
                }
            }

            if (v != null)
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
                    TempData["Message"] = "Logged In Successfully";
                    return RedirectToAction("Dashboard", "User");
                }
            }
            TempData["Message"] = "Invalid Credentials!";
            return View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult Dashboard()
        {
            ViewBag.Message = TempData["Message"];
            return View();
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            TempData["Message"] = "Logout Successfully";
            return RedirectToAction("Login", "User");
        }

        [NonAction]
        public bool IsEmailExist(string emailID)
        {
            bool checkEmail = true;
            using(var client = new HttpClient())
            {
                string getUri = "https://localhost:44376/CheckEmailId?Email="+emailID;
                var responseTask = client.GetAsync(getUri);

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<bool>();
                    checkEmail = readTask.Result;
                }
            }
            return checkEmail;
        }
    }
}
