using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SBM.BAL.ManagerInterface;

namespace SBM.WebApi.Controllers
{
    public class RecordController : ApiController
    {
        private readonly IRecordManager _recordManager;

        public RecordController(IRecordManager recordManager)
        {
            _recordManager = recordManager;
        }
    }
}
