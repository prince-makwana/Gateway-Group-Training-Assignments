using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRM.WebAPI.Filter
{
    public class ResponseHeaderFilter : ActionFilterAttribute
    {
        private string _header;
        public ResponseHeaderFilter(string header)
        {
            _header = header;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            context.HttpContext.Response.Headers.Add("Created-By: ", _header);
        }
    }
}
