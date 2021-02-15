using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http.Filters;

namespace SBM.WebApi
{
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
        //public override void OnAuthorization(HttpActionExecutedContext actionExecutedContext)
        //{
        //    if(actionExecutedContext.Request.Headers.Authorization == null)
        //    {
        //        actionExecutedContext.Response = actionExecutedContext.Request.
        //            CreateResponse(System.Net.HttpStatusCode.Unauthorized);
        //    }
        //    else
        //    {
        //        string authenticationToken = actionExecutedContext.Request.Headers.Authorization.Parameter;
        //        string decodedauthenticationToken = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationToken);
        //        string[] usernamePasswordArray = decodedauthenticationToken.Split(':');
        //        string username = usernamePasswordArray[0];
        //        string password = usernamePasswordArray[1];

        //        if()
        //    }
        //}

        //public static bool IsAuthorizedUser(string Username, string Password)
        //{
        //    return 
        //}
    }
}