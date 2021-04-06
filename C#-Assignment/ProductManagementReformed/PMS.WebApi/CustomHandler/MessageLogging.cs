using PMS.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.WebAPI.CustomHandler
{
    public class MessageLogging
    {
        public void IncomingMessageAsync(ApiLogViewModel apiLog)
        {
            apiLog.RequestType = "Request";
            var sqlErrorLogging = new ApiLogging();
            sqlErrorLogging.InsertLog(apiLog);
        }

        public void OutgoingMessageAsync(ApiLogViewModel apiLog)
        {
            apiLog.RequestType = "Response";
            var sqlErrorLogging = new ApiLogging();
            sqlErrorLogging.InsertLog(apiLog);
        }
    }
}