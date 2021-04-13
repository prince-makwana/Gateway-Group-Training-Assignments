using HRM.Common.WebClient;
using HRM.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger _logger;
        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Login Get method to display login page
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Login Post method for authentication
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDTO model)
        {
            if (ModelState.IsValid)
            {
                if(await UserAuthentication(new UserLogin { Email = model.Email, Password = model.Password }))
                {
                    TempData["message"] = "Login Successfully!";
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
                TempData["message"] = "Model State not valid!";
                return RedirectToAction("Login", "Account");
            }
        }

        /// <summary>
        /// Non Action method to send Post request to userlogin API for authentication
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private async Task<bool> UserAuthentication(UserLogin user)
        {
            try
            {
                _logger.LogInformation("Inside USer Authentication() method");
                var model = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                var postTask = WebClient.httpClient.PostAsync("UserLogin", model);
                  
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
            catch (Exception ex)
            {
                _logger.LogError("Error at User Authentication in Account Controller " + ex.Message.ToString());
                return false;
            }
        }

        /// <summary>
        /// Logout MEthod
        /// </summary>
        /// <returns></returns>
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("user");
            HttpContext.Session.Remove("token");
            return RedirectToAction("Login", "Account");
        }
    }
}
