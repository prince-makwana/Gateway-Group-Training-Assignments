using System;
using System.Collections.Generic;
using System.Text;

namespace HRM.Models
{
    public class UserLogin
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }
}
