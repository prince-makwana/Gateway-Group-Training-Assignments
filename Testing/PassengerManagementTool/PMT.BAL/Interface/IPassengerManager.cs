using PMT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMT.BAL.Interface
{
    public interface IPassengerManager
    {
        List<PassengerViewModel> GetPassengers();
        PassengerViewModel GetPassenger(int? id);
        string AddPassengers(PassengerViewModel model);
        string UpdatePassengers(int? id, PassengerViewModel model);
        bool DeletePassenger(int? id);
    }
}
