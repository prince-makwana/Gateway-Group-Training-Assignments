using PMS.BAL.ManagerInterface;
using PMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PMS.WebAPI.Controllers
{
    public class UsersController : ApiController
    {
        private readonly IUserManager _userManager;

        public UsersController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        /// <summary>
        /// Get All Users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllUsers")]
        public IHttpActionResult GetAllUsers()
        {
            var res = _userManager.GetAllUsers();
            if(res == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(res);
            }
        }

        /// <summary>
        /// Get User By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetUserById/{id}")]
        public IHttpActionResult GetUserById(int id)
        {
            var res = _userManager.GetUserById(id);
            if(res == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(res);
            }
        }

        /// <summary>
        /// Check Email exists
        /// </summary>
        /// <param name="Email"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("CheckEmailId")]
        public IHttpActionResult CheckEmailId(string Email)
        {
            return Ok(_userManager.checkEmailExists(Email));
        }

        /// <summary>
        /// To Login the User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UserLogin")]
        public IHttpActionResult UserLogin([FromBody]UserLogin user)
        {
            var res = _userManager.UserLogin(user);
            if (res == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(res);
            }
        }

        /// <summary>
        /// To create an account of user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("RegisterUser")]
        public IHttpActionResult RegisterUser([FromBody]UserVM user)
        {
            if (ModelState.IsValid) 
            { 
            var res = _userManager.RegisterUser(user);
                if (res)
                {
                    return Ok("Registered Successfully!");
                }
                else
                {
                    return BadRequest("Internal Server Error");
                }
            }
            return BadRequest("Model not valid");
        }
    }
}
