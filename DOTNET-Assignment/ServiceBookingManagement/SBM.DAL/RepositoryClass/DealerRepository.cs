using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SBM.DAL.RepositoryInterface;
using SBM.Models;

namespace SBM.DAL.RepositoryClass
{
    public class DealerRepository : IDealerRepository
    {
        private readonly Database.ServiceBookingDBEntities _dbContext;

        public DealerRepository()
        {
            _dbContext = new Database.ServiceBookingDBEntities();
        }

        public string createDealer(Dealers model)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Dealers, Database.tblDealer>());
            var mapper = config.CreateMapper();

            try
            {
                if (model != null)
                {
                    Database.tblDealer entity = mapper.Map<Database.tblDealer>(model);
                    //entity.Password = PasswordHash.Hash(model.Password);
                    _dbContext.tblDealers.Add(entity);
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

        public string deleteDealer(int id)
        {
            var entity = _dbContext.tblDealers.Find(id);

            if (entity != null)
            {
                _dbContext.tblDealers.Remove(entity);
                _dbContext.SaveChanges();

                return "Account Closed Successfully!";
            }
            return "Account does not exist. Contact Admin.";
        }


        public Dealers GetDealerByEmailId(string emailId)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Database.tblDealer, Dealers>());
            var mapper = config.CreateMapper();

            Database.tblDealer entity = (from user in _dbContext.tblDealers
                                           where user.EmailId == emailId
                                           select user).FirstOrDefault();

            Dealers data = mapper.Map<Dealers>(entity);
            return data;
        }

        public string updateDealer(Dealers model)
        {
            var entity = _dbContext.tblDealers.Find(model.DealerId);
            if (entity != null)
            {
                entity.UpdatedDate = DateTime.Now;
                _dbContext.SaveChanges();
                return "Account Updated Successfully!";
            }
            return "Something went wrong. Please try after sometime.";
        }
    }
}
