using PMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.BAL.ManagerInterface
{
    public interface IUserManager
    {
        string CreateUser(User model);
        UserViewModel GetUser(UserLogin model);
        string UpdateUser(User model);
    }
}
