using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.WebAPI.Models
{
    public class APIErrorViewModel
    {
        public int APIErrorId { get; set; }
        public string RequestMethod { get; set; }
        public string RequestUri { get; set; }
        public Nullable<System.DateTime> Time { get; set; }
        public string Message { get; set; }
    }
}