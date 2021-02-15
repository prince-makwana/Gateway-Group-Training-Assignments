using SBM.BAL.ManagerInterface;
using SBM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SBM.WebApi.Controllers
{
    public class AccountController : ApiController
    {
        private readonly IAccountManager _accountManager;

        public AccountController(IAccountManager accountManager)
        {
            _accountManager = accountManager;
        }

        [HttpPost]
        public IHttpActionResult Login([FromBody] UserLogin model)
        {
            var result = _accountManager.loginAccount(model);

            if(result == true)
            {
                return Ok();
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
