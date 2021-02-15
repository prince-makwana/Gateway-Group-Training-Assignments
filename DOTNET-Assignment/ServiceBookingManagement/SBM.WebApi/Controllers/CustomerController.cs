using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SBM.BAL.ManagerInterface;
using SBM.Models;

namespace SBM.WebApi.Controllers
{
    public class CustomerController : ApiController
    {
        private readonly ICustomerManager _customerManager;

        public CustomerController(ICustomerManager customerManager)
        {
            _customerManager = customerManager;
        }

        [HttpPost]
        public IHttpActionResult RegisterCustomer([FromBody] Customers model)
        {
            if (model != null)
            {
                return Ok(_customerManager.createCustomer(model));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("Customer/GetCustomerInfo")]
        public Customers GetCustomerByEmailId(string emailId)
        {
            return _customerManager.GetCustomerByEmailId(emailId);
        }
    }
}
