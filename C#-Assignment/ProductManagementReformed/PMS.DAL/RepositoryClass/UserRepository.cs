using PMS.DAL.RepositoryInterface;
using PMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PMS.DAL.Database;

namespace PMS.DAL.RepositoryClass
{
    public class UserRepository : IUserRepository
    {
        private readonly Database.ProductManagementEntities _dbContext;

        public UserRepository()
        {
            _dbContext = new Database.ProductManagementEntities();
        }

        public List<UserVM> GetAllUsers()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<User, UserVM>());
            var mapper = new Mapper(config); 

            List<UserVM> userList = new List<UserVM>();
            try
            {
                var entities = _dbContext.Users.ToList();
                
                if(entities == null)
                {
                    userList = null;
                }
                else
                {
                    foreach (var item in entities)
                    {
                        var user = mapper.Map<UserVM>(item);
                        userList.Add(user);
                    }
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return userList;
        }

        public UserVM GetUserById(int id)
        {
            UserVM user = new UserVM();
            try
            {
                user = GetAllUsers().FirstOrDefault(u => u.ID == id);
                if(user == null)
                {
                    user = null;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return user;
        }

        public bool checkEmailExists(string Email)
        {
            bool result = true;
            try
            {
                result = GetAllUsers().Any(u => u.Email == Email);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        public UserVM UserLogin(UserLogin user)
        {
            UserVM userVM = new UserVM();
            try
            {
                userVM = GetAllUsers().SingleOrDefault(u => u.Email == user.EmailID && u.Password == user.Password);

                if(userVM == null)
                {
                    userVM = null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return userVM;
        }

        public bool RegisterUser(UserVM user)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UserVM, User>());
            var mapper = new Mapper(config);

            var newUser = mapper.Map<User>(user);
            try
            {
                _dbContext.Users.Add(newUser);
                _dbContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return false;
        }
    }
}
