using HRM.BAL;
using HRM.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using HRM.WebAPI.Filter;

namespace HRM.WebAPI.Controllers
{
    //[Route("api/[controller]")]
    [ResponseHeaderFilter]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeManager _employeeManager;

        public EmployeeController(IEmployeeManager employeeManager)
        {
            _employeeManager = employeeManager;
        }

        /// <summary>
        /// Get List of all Employees API
        /// </summary>
        /// <returns></returns>
        [Route("GetEmployees")]
        [HttpGet]
        public IActionResult GetEmployee()
        {
            var employees = _employeeManager.getAllemployees();
            if(employees.Count() != 0)
            {
                return Ok(employees);
            }
            else
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Get Employee By Id API
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("GetEmployeeById/{id}")]
        [HttpGet]
        public IActionResult GetEmployeeById(int id)
        {
            var result = _employeeManager.GetEmployeeById(id);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Add an Employee API
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddEmployee")]
        public IActionResult AddEmployee(CreateEmployeeDTO model)
        {
            var result = _employeeManager.AddEmployee(model);
            if (result)
            {
                return Ok();
            }
            else
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Edit an Employee API 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("EditEmployee")]
        public IActionResult UpdateEmployee(EmployeeDTO model)
        {
            var result = _employeeManager.UpdateEmployee(model);
            if (result)
            {
                return Ok();
            }
            else
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Delete an Employee API
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteEmployee/{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var result = _employeeManager.DeleteEmployee(id);
            if (result)
            {
                return Ok();
            }
            else
            {
                return StatusCode(500);
            }
        }
    }
}
