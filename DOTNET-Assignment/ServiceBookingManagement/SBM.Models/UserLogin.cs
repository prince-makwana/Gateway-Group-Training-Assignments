using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SBM.Models
{
    public class UserLogin
    {
        public UserType User { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
    }

    public enum UserType
    {
        Dealer,
        Customer
    }
}