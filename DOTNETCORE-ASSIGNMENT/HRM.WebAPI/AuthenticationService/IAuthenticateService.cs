using HRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRM.WebAPI.AuthenticationService
{
    public interface IAuthenticateService
    {
        UserLogin Authenticate(string Email, string Password);
    }
}
