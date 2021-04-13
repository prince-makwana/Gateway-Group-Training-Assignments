using HRM.Common.WebClient;
using HRM.Models;
using HRM.MVC.CustomFilters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace HRM.MVC.Controllers
{
    [AuthSessionManagement]
    public class EmployeeController : Controller
    {
        /// <summary>
        /// Add an Employee Page
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult AddEmployee()
        {
            var message = TempData["message"];
            if (message != null)
            {
                ViewBag.Message = message.ToString();
            }
            return View();
        }

        /// <summary>
        /// Dashboard Page
        /// </summary>
        /// <returns></returns>
        public IActionResult Dashboard()
        {
            var message = TempData["message"];
            if (message != null)
            {
                ViewBag.Message = message.ToString();
            }
            return View();
        }

        /// <summary>
        /// Add an Employee POST method
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddEmployee(EmployeeDTO employee)
        {
            if (ModelState.IsValid)
            {
                //HTTP POST
                WebClient.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
                var postTask = WebClient.httpClient.PostAsJsonAsync<EmployeeDTO>("AddEmployee", employee);


                var result = postTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    TempData["message"] = "Added Successfully!";
                    return RedirectToAction("EmployeeList", "Employee");
                }
               
            }
            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
            TempData["message"] = "Server Error. Please contact administrator.";
            return RedirectToAction("AddEmployee", "Employee");
        }

        /// <summary>
        /// EmployeeList Page
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ResponseCache(Duration = (int)0.5)]
        public IActionResult EmployeeList()
        {
            IEnumerable<EmployeeDTO> employees = null;
            
            //HTTP GET
            WebClient.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
            var responseTask = WebClient.httpClient.GetAsync("GetEmployees");

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadFromJsonAsync<IEnumerable<EmployeeDTO>>();
                employees = readTask.Result;
            }
            else
            {
                employees = Enumerable.Empty<EmployeeDTO>();
                ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
            }
            ViewData["Message_t"] = "The current time is: " + DateTime.Now.ToString();
            return View(employees);
        }

        /// <summary>
        /// Details Page
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            else
            {
                var employee = GetEmployeeById(id);
                var message = TempData["message"];
                if (message != null)
                {
                    ViewBag.Message = message.ToString();
                }
                return View(employee);
            }
        }

        /// <summary>
        /// Delete Page
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult DeleteEmployee(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var employee = GetEmployeeById(id);

            if(employee == null)
            {
                return NotFound();
            }
            var message = TempData["message"];
            if (message != null)
            {
                ViewBag.Message = message.ToString();
            }
            return View(employee);
        }

        /// <summary>
        /// Delete Method POST action
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteEmployee(int id)
        {
            //HTTP DELETE
            WebClient.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
            var deleteTask = WebClient.httpClient.DeleteAsync("DeleteEmployee/" + id);
            
            var result = deleteTask.Result;

            if (result.IsSuccessStatusCode)
            {
                TempData["message"] = "Deleted Successfully!";
                return RedirectToAction("EmployeeList", "Employee");
            }

            TempData["message"] = "Server Error. Please try after sometime.";
            return RedirectToAction("EmployeeList", "Employee");
        }

        /// <summary>
        /// Edit Employee Page
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult EditEmployee(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var employee = GetEmployeeById(id);

            if(employee == null)
            {
                return NotFound();
            }
            var message = TempData["message"];
            if (message != null)
            {
                ViewBag.Message = message.ToString();
            }
            return View(employee);
        }

        /// <summary>
        /// Get Employee By Id Non Action Method to consume API
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [NonAction]
        public EmployeeDTO GetEmployeeById(int? id)
        {
            EmployeeDTO employee;

            //HTTP GET
            WebClient.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
            var responseTask = WebClient.httpClient.GetAsync("GetEmployeeById/" + id);

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadFromJsonAsync<EmployeeDTO>();
                employee = readTask.Result;
            }
            else
            {
                employee = null;
                ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
            }
            
            return employee;
        }

        /// <summary>
        /// Edit Employee POST Action
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditEmployee(EmployeeDTO employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //HTTP PUT
                    WebClient.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
                    var responseTask = WebClient.httpClient.PutAsJsonAsync("EditEmployee", employee);

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        TempData["message"] = "Updated Successfully!";
                        return RedirectToAction("EmployeeList", "Employee");
                    }
                }
                catch (DbUpdateConcurrencyException)
                {

                }
            }
            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
            TempData["message"] = "Server Error. Please contact administrator.";
            return View(employee);
        }
    }
}
