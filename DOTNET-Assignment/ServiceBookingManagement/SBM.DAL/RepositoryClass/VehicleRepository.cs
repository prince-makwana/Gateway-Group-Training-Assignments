using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBM.DAL.RepositoryInterface;

namespace SBM.DAL.RepositoryClass
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly Database.ServiceBookingDBEntities _dbContext;

        public VehicleRepository()
        {
            _dbContext = new Database.ServiceBookingDBEntities();
        }
    }
}
