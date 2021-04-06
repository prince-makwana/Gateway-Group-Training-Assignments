using PMS.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ExceptionHandling;

namespace PMS.WebAPI.CustomHandler
{
    public class UnhandledExceptionLogger : ExceptionLogger
    {
        public override void Log(ExceptionLoggerContext context)
        {
            var ex = context.Exception;

            string strLogText = "";
            strLogText += Environment.NewLine + "Source ---\n{0}" + ex.Source;
            strLogText += Environment.NewLine + "StackTrace ---\n{0}" + ex.StackTrace;
            strLogText += Environment.NewLine + "TargetSite ---\n{0}" + ex.TargetSite;

            if (ex.InnerException != null)
            {
                strLogText += Environment.NewLine + "Inner Exception is {0}" + ex.InnerException;
            }
            if (ex.HelpLink != null)
            {
                strLogText += Environment.NewLine + "HelpLink ---\n{0}" + ex.HelpLink;
            }

            var requestedUri = (string)context.Request.RequestUri.AbsoluteUri;
            var requestedMethod = context.Request.Method.ToString();
            var timeUtc = DateTime.Now;

            SQLErrorLogging sqlErrorLogging = new SQLErrorLogging();

            APIErrorViewModel apiError = new APIErrorViewModel()
            {
                Message = strLogText,
                RequestUri = requestedUri,
                RequestMethod = requestedMethod,
                Time = timeUtc
            };

            sqlErrorLogging.InsertErrorLog(apiError);
        }
    }
}