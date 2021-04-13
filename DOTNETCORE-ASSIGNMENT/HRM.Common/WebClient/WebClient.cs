using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Net.Http.Headers;

namespace HRM.Common.WebClient
{
    public static class WebClient
    {
        public static HttpClient httpClient = new HttpClient();
        static WebClient()
        {
            httpClient.BaseAddress = new Uri("https://localhost:44367/");
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        } 
    }
}
