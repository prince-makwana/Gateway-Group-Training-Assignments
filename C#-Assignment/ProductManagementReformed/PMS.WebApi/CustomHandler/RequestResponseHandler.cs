using PMS.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace PMS.WebAPI.CustomHandler
{
    public class RequestResponseHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
        CancellationToken cancellationToken)
        {
            // To store request method (POST, PUT, DELETE, GET)
            var requestedMethod = request.Method;
            
            // To store host IP Address
            var userHostAddress = HttpContext.Current != null ? HttpContext.Current.Request.UserHostAddress : "0.0.0.0";
            
            // The agent who is requesting the API call
            var useragent = request.Headers.UserAgent.ToString();

            // The agent requested message from an api call
            var requestMessage = await request.Content.ReadAsByteArrayAsync();

            //The Uri accessed by user
            var uriAccessed = request.RequestUri.AbsoluteUri;

            // Collects the response header data
            var responseHeadersString = new StringBuilder();
            foreach (var header in request.Headers)
            {
                responseHeadersString.Append($"{header.Key}: {String.Join(", ", header.Value)}{Environment.NewLine}");
            }

            var messageLoggingHandler = new MessageLogging();

            // Assingning the value to apilog view model for Request Logging
            var requestLog = new ApiLogViewModel()
            {
                Headers = responseHeadersString.ToString(),
                AbsoluteUri = uriAccessed,
                Host = userHostAddress,
                RequestBody = Encoding.UTF8.GetString(requestMessage),
                UserHostAddress = userHostAddress,
                Useragent = useragent,
                RequestedMethod = requestedMethod.ToString(),
                StatusCode = string.Empty
            };

            messageLoggingHandler.IncomingMessageAsync(requestLog);

            // Assingning the value to apilog view model for Response Logging
            var response = await base.SendAsync(request, cancellationToken);

            byte[] responseMessage;
            if (response.IsSuccessStatusCode)
                responseMessage = await response.Content.ReadAsByteArrayAsync();
            else
                responseMessage = Encoding.UTF8.GetBytes(response.ReasonPhrase);

            var responseLog = new ApiLogViewModel()
            {
                Headers = responseHeadersString.ToString(),
                AbsoluteUri = uriAccessed,
                Host = userHostAddress,
                RequestBody = Encoding.UTF8.GetString(responseMessage),
                UserHostAddress = userHostAddress,
                Useragent = useragent,
                RequestedMethod = requestedMethod.ToString(),
                StatusCode = string.Empty
            };

            messageLoggingHandler.OutgoingMessageAsync(responseLog);
            return response;
        }
    }
}