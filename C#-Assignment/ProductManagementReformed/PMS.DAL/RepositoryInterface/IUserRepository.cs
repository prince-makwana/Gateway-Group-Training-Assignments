using PMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.DAL.RepositoryInterface
{
    public interface IUserRepository
    {
        List<UserVM> GetAllUsers();
        UserVM GetUserById(int id);
        bool checkEmailExists(string Email);
        UserVM UserLogin(UserLogin user);
        bool RegisterUser(UserVM user);
    }
}
