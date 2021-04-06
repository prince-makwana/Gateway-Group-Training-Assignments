using PMS.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.WebAPI.CustomHandler
{
    public class ApiLogging
    {
        public void InsertLog(ApiLogViewModel apiLog)
        {
            try
            {
                using (var logContext = new PMLoggingEntities())
                {
                    logContext.ApiLogs.Add(new ApiLog()
                    {
                        Host = apiLog.Host,
                        Headers = apiLog.Headers,
                        StatusCode = apiLog.StatusCode,
                        RequestBody = apiLog.RequestBody,
                        RequestedMethod = apiLog.RequestedMethod,
                        UserHostAddress = apiLog.UserHostAddress,
                        Useragent = apiLog.Useragent,
                        AbsoluteUri = apiLog.AbsoluteUri,
                        RequestType = apiLog.RequestType
                    });

                    logContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}