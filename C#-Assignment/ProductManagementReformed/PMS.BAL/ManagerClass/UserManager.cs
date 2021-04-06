using PMS.BAL.ManagerInterface;
using PMS.DAL.RepositoryInterface;
using PMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.BAL.ManagerClass
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool checkEmailExists(string Email)
        {
            return _userRepository.checkEmailExists(Email);
        }

        public List<UserVM> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public UserVM GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }

        public bool RegisterUser(UserVM user)
        {
            return _userRepository.RegisterUser(user);
        }

        public UserVM UserLogin(UserLogin user)
        {
            return _userRepository.UserLogin(user);
        }
    }
}
