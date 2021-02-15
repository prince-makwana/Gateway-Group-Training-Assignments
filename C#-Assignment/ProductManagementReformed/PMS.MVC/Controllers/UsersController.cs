using PMS.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PMS.MVC.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult RegisterUser()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterUser(User user)
        {
            using (var client = new HttpClient())
            {
                string requestUri = "https://localhost:44357/RegisterUser";

                //HTTP POST
                var postTask = client.PostAsJsonAsync<User>(requestUri, user);
                var result = postTask.Result;

                if(result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Login", "Users");
                }
                return RedirectToAction("RegisterUser", "Users", new { are = "" });
            }
        }

        [Authorize]
        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLogin login)
        {
            using (var client = new HttpClient())
            {
                string requestUri = "https://localhost:44357/Login";

                UserViewModel result = new UserViewModel();
                //HTTP POST
                var response = client.PostAsJsonAsync<UserLogin>(requestUri, login).Result;


                if (response.IsSuccessStatusCode)
                {
                    int timeout = login.RememberMe ? 1440 : 60; //1440 min = 1 year
                    var ticket = new FormsAuthenticationTicket(login.EmailId, login.RememberMe, timeout);
                    string encrypted = FormsAuthentication.Encrypt(ticket);
                    var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                    cookie.Expires = DateTime.Now.AddMinutes(timeout);
                    cookie.HttpOnly = true;
                    Response.Cookies.Add(cookie);

                    UserViewModel user = response.Content.ReadFromJsonAsync<UserViewModel>().Result;
                    if (user != null)
                    {
                        Session["UserId"] = user.UserId;
                        Session["EmailId"] = user.EmailId;
                        Session["Name"] = user.Name;

                        return RedirectToAction("Dashboard", "Users");
                    }
                    else
                    {
                        return View();
                    }
                }
                else
                {
                    return View();
                }
            }
        }

        [HttpPost]
        [Authorize]
        public ActionResult Logout()
        {
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            cookie.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie);

            FormsAuthentication.SignOut();

            Session.Abandon();
            Session.Clear();
            return RedirectToAction("Login", "Users", new { are = "" });
        }

    }
}