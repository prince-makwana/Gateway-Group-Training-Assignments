using HRM.Models;
using HRM.WebAPI.AuthenticationService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRM.WebAPI.Controllers
{
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IAuthenticateService _authenticateService;
        public AccountController(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }

        /// <summary>
        /// UserLogin POST method API
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UserLogin")]
        public IActionResult UserLogin([FromBody] UserLogin user)
        {
            var result = _authenticateService.Authenticate(user.Email, user.Password);
            if(result == null)
            {
                return BadRequest(new { message = "Email or Password is incorrect" });
            }
            else
            {
                return Ok(result);
            }
        }
    }
}
