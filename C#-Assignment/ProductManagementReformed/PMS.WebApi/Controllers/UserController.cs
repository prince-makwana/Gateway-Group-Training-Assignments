using PMS.BAL.ManagerInterface;
using PMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PMS.WebApi.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserManager _userManager;

        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpPost, Route("RegisterUser")]
        public string CreateUser([FromBody]User model)
        {
            return _userManager.CreateUser(model);
        }

        [HttpPost, Route("Login")]
        public UserViewModel GetUser([FromBody]UserLogin model)
        {
            return _userManager.GetUser(model);
        }
    }
}
