using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SBM.BAL.ManagerInterface;

namespace SBM.WebApi.Controllers
{
    public class VehicleController : ApiController
    {
        private readonly IVehicleManager _vehicleManager;
        public VehicleController(IVehicleManager vehicleManager)
        {
            _vehicleManager = vehicleManager;
        }
    }
}
