using PMS.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.WebAPI.CustomHandler
{
    public class SQLErrorLogging
    {
        public void InsertErrorLog(APIErrorViewModel apiError)
        {
            try
            {
                using (var logContext = new PMLoggingEntities())
                {
                    logContext.APIErrors.Add(new APIError()
                    {
                        RequestMethod = apiError.RequestMethod,
                        RequestUri = apiError.RequestUri,
                        Time = apiError.Time,
                        Message = apiError.Message
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