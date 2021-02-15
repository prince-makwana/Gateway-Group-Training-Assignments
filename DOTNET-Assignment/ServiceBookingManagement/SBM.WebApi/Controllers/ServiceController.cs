using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SBM.BAL.ManagerInterface;

namespace SBM.WebApi.Controllers
{
    public class ServiceController : ApiController
    {
        private readonly IServiceManager _serviceManager;

        public ServiceController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
    }
}
