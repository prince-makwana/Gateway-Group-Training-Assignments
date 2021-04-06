using PMS.WebAPI.CustomHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.ExceptionHandling;

namespace PMS.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            //Registering global Exception Handler
            config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());

            //Registering UnhandledExceptionLogger
            config.Services.Replace(typeof(IExceptionLogger), new UnhandledExceptionLogger());

            //Registering RequestResponseHandler
            config.MessageHandlers.Add(new RequestResponseHandler());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));
        }
    }
}
