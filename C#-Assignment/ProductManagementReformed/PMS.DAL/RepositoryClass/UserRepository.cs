using AutoMapper;
using PMS.DAL.RepositoryInterface;
using PMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.DAL.RepositoryClass
{
    public class UserRepository : IUserRepository
    {
        private readonly Database.ProductManagmentEntities _dbContext;
        public UserRepository()
        {
            _dbContext = new Database.ProductManagmentEntities();
        }

        /// <summary>
        /// Registration of New User
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string CreateUser(User model)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<User, Database.tblUser>());
            var mapper = config.CreateMapper();

            var user = mapper.Map<Database.tblUser>(model);

            _dbContext.tblUsers.Add(user);
            _dbContext.SaveChanges();

            return "Registration successfully";
        }

        /// <summary>
        /// Login of a new User
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public UserViewModel GetUser(UserLogin model)
        {
            if(model == null)
            {
                return null;
            }
            else
            {
                var result = (from u in _dbContext.tblUsers
                              where (u.EmailId == model.EmailId)
                              && (u.Password == model.Password) select u).FirstOrDefault();

                UserViewModel user = new UserViewModel()
                {
                    EmailId = result.EmailId,
                    Name = result.Name,
                    UserId = result.UserId
                };
                return user;
            }
        }

        /// <summary>
        /// Update User Details.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string UpdateUser(User model)
        {
            var entity = _dbContext.tblUsers.Find(model.UserId);
            if (entity != null)
            {
                entity.Name = model.Name;
                entity.ContactNo = model.ContactNo;
                entity.EmailId = model.EmailId;
                entity.Password = model.Password;

                _dbContext.SaveChanges();
                return "Updated Successfully!";
            }
            else
            {
                return "Something went wrong. Please try after sometime.";
            }
        }
    }
}
