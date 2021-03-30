using HRM.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace HRM.MVC.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            var message = TempData["message"];
            if(message != null)
            {
                ViewBag.Message = message.ToString();
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDTO model)
        {
            if (ModelState.IsValid)
            {
                if(await UserAuthentication(new UserLogin { Email = model.Email, Password = model.Password }))
                {
                    return RedirectToAction("Dashboard", "Employee");
                }
                else
                {
                    TempData["message"] = "Invalid Credentials";
                    return RedirectToAction("Login", "Account");
                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        private async Task<bool> UserAuthentication(UserLogin user)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    string postUri = "https://localhost:44367/api/Account/UserLogin";

                    var model = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

                    var postTask = client.PostAsJsonAsync(postUri, user);
                    var result = postTask.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        string response = await result.Content.ReadAsStringAsync();
                        user = JsonConvert.DeserializeObject<UserLogin>(response);
                        HttpContext.Session.SetString("token", user.Token);
                        HttpContext.Session.SetString("user", user.Email);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                } 
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("user");
            HttpContext.Session.Remove("token");
            return RedirectToAction("Login", "Account");
        }
    }
}
