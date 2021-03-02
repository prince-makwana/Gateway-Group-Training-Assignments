using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMT.Models;

namespace PMT.DAL.Repository
{
    public interface IPassengerRepository
    {
        List<PassengerViewModel> GetPassengers();
        PassengerViewModel GetPassenger(int? id);
        string AddPassengers(PassengerViewModel model);
        string UpdatePassengers(int? id, PassengerViewModel model);
        bool DeletePassenger(int? id);
    }
}
