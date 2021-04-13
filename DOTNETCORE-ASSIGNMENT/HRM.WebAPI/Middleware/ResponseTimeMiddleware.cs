using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HRM.WebAPI.Middleware
{
    public class ResponseTimeMiddleware
    {
        private readonly ILogger _logger;
        private const string Response_Header = "Response-Time-ms";
        private readonly RequestDelegate _next;

        public ResponseTimeMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<ResponseTimeMiddleware>();
        }

        public Task InvokeAsync(HttpContext context)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            context.Response.OnStarting(() =>
            {
                stopwatch.Stop();
                var totalResponseTime = stopwatch.ElapsedMilliseconds;
                //Adding Total Response Time information in Response Header.
                _logger.LogInformation(Response_Header + ":" + totalResponseTime.ToString());
                context.Response.Headers[Response_Header] = totalResponseTime.ToString();
                return Task.CompletedTask;
            });
            // Call the next Middleware in the pipeline
            return this._next(context);
        }
    }
}
