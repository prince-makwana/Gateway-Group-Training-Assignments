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
    public class DealerController : ApiController
    {
        private readonly IDealerManager _dealerManager;

        public DealerController(IDealerManager dealerManager)
        {
            _dealerManager = dealerManager;
        }

        [HttpPost]
        public IHttpActionResult RegisterDealer([FromBody] Dealers model)
        {
            if (model != null)
            {
                return Ok(_dealerManager.createDealer(model));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet,Route("Dealer/GetDealerInfo")]
        public Dealers GetDealerByEmailId(string emailId)
        {
            return _dealerManager.GetDealerByEmailId(emailId);
        }
    }
}
