using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBM.DAL.RepositoryInterface;

namespace SBM.DAL.RepositoryClass
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly Database.ServiceBookingDBEntities _dbContext;

        public AppointmentRepository()
        {
            _dbContext = new Database.ServiceBookingDBEntities();
        }
    }
}
