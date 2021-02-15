using SBM.DAL.RepositoryInterface;
using SBM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBM.Common;

namespace SBM.DAL.RepositoryClass
{
    public class AccountRepository : IAccountRepository
    {
        private readonly Database.ServiceBookingDBEntities _dbContext;

        public AccountRepository()
        {
            _dbContext = new Database.ServiceBookingDBEntities();
        }

        public bool loginAccount(UserLogin model)
        {
            //var pass = PasswordHash.Hash(model.Password);
            if(model.User == UserType.Customer)
            {
                bool result = _dbContext.tblCustomers.Any(
                    user => user.EmailId.Equals(model.EmailId)
                    && user.Password == model.Password
                );
                return result;
            }
            else
            {
                bool result = _dbContext.tblDealers.Any(
                    user => user.EmailId.Equals(model.EmailId)
                    && user.Password == model.Password
                    );
                return result;
            }
            
        }
    }
}
