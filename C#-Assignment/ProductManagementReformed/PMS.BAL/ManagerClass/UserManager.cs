using PMS.BAL.ManagerInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.DAL.RepositoryInterface;
using PMS.Model;

namespace PMS.BAL.ManagerClass
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _userRepository;
        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public string CreateUser(User model)
        {
            return _userRepository.CreateUser(model);
        }

        public UserViewModel GetUser(UserLogin model)
        {
            return _userRepository.GetUser(model);
        }

        public string UpdateUser(User model)
        {
            return _userRepository.UpdateUser(model);
        }
    }
}
