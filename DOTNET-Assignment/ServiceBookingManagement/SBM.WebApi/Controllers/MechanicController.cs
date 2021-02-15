using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SBM.BAL.ManagerInterface;

namespace SBM.WebApi.Controllers
{
    public class MechanicController : ApiController
    {
        private readonly IMechanicManager _mechanicManager;

        public MechanicController(IMechanicManager mechanicManager)
        {
            _mechanicManager = mechanicManager;
        }
    }
}
