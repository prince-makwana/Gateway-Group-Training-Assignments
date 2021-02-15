using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SBM.DAL.RepositoryInterface;
using SBM.Models;
using SBM.Common;

namespace SBM.DAL.RepositoryClass
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly Database.ServiceBookingDBEntities _dbContext;

        public CustomerRepository()
        {
            _dbContext = new Database.ServiceBookingDBEntities();
        }

        public string createCustomer(Customers model)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Customers, Database.tblCustomer>());
            var mapper = config.CreateMapper();

            try
            {
                if(model != null)
                {
                    Database.tblCustomer entity = mapper.Map<Database.tblCustomer>(model);
                    //entity.Password = PasswordHash.Hash(model.Password);
                    _dbContext.tblCustomers.Add(entity);
                    _dbContext.SaveChanges();
                    return "Registered Successfully!";
                }
                else
                {
                    return "Data Not Found!";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string deleteCustomer(int id)
        {
            var entity = _dbContext.tblCustomers.Find(id);

            if(entity != null)
            {
                _dbContext.tblCustomers.Remove(entity);
                _dbContext.SaveChanges();

                return "Account Closed Successfully!";
            }
            return "Account does not exist. Contact Admin.";
        }

        public Customers GetCustomerByEmailId(string emailId)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Database.tblCustomer, Customers>());
            var mapper = config.CreateMapper();

            Database.tblCustomer entity = (from user in _dbContext.tblCustomers
                       where user.EmailId == emailId
                       select user).FirstOrDefault();

            Customers data = mapper.Map<Customers>(entity);
            return data;
        }

        public string updateCustomer(Customers model)
        {
            var entity = _dbContext.tblCustomers.Find(model.CustomerId);
            if(entity != null)
            {
                entity.UpdatedDate = DateTime.Now;
                _dbContext.SaveChanges();
                return "Account Updated Successfully!";
            }
            return "Something went wrong. Please try after sometime.";
        }
    }
}
