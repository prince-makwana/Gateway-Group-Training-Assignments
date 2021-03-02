using PMT.DAL.Database;
using PMT.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMT.DAL.Repository
{
    public class PassengerRepository : IPassengerRepository
    {
        private readonly Database.PassengerDBEntities _dbContext;

        public PassengerRepository()
        {
            _dbContext = new Database.PassengerDBEntities();
        }

        public string AddPassengers(PassengerViewModel model)
        {
            try
            {
                if(model != null)
                {
                    tblPassenger passenger = new tblPassenger();
                    passenger.ID = model.ID;
                    passenger.FName = model.FName;
                    passenger.LName = model.LName;
                    passenger.MobileNo = model.MobileNo;

                    _dbContext.tblPassengers.Add(passenger);
                    _dbContext.SaveChanges();
                    return "Passenger added successfully.";
                }
                return "Model is Null.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public bool DeletePassenger(int? id)
        {
            var entity = _dbContext.tblPassengers.Find(id);
            if(entity != null)
            {
                _dbContext.tblPassengers.Remove(entity);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public PassengerViewModel GetPassenger(int? id)
        {
            try
            {
                var entity = _dbContext.tblPassengers.Find(id);
                PassengerViewModel passenger = new PassengerViewModel();
                passenger.ID = entity.ID;
                passenger.FName = entity.FName;
                passenger.LName = entity.LName;
                passenger.MobileNo = entity.MobileNo;
                return passenger;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<PassengerViewModel> GetPassengers()
        {
            var entity = _dbContext.tblPassengers.ToList();
            List<PassengerViewModel> passengerList = new List<PassengerViewModel>();

            if(_dbContext != null)
            {
                foreach (var item in entity)
                {
                    PassengerViewModel passenger = new PassengerViewModel();
                    passenger.ID = item.ID;
                    passenger.FName = item.FName;
                    passenger.LName = item.LName;
                    passenger.MobileNo = item.MobileNo;

                    passengerList.Add(passenger);
                }
            }
            return passengerList;
        }

        public string UpdatePassengers(int? id, PassengerViewModel model)
        {
            try
            {
                tblPassenger passenger = new tblPassenger();
                if (model != null)
                {
                    passenger.ID = model.ID;
                    passenger.FName = model.FName;
                    passenger.LName = model.LName;
                    passenger.MobileNo = model.MobileNo;
                    _dbContext.Entry(passenger).State = EntityState.Modified;
                    _dbContext.SaveChanges();
                    return "Passenger Updated Successfully";
                }
                return "Model is null!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
