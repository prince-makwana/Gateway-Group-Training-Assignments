using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SBM.BAL.ManagerInterface;

namespace SBM.WebApi.Controllers
{
    public class JobCardController : ApiController
    {
        private readonly IJobCardManager _jobCardManager;

        public JobCardController(IJobCardManager jobCardManager)
        {
            _jobCardManager = jobCardManager;
        }
    }
}
