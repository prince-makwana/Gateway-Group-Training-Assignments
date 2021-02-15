using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBM.DAL.RepositoryInterface;

namespace SBM.DAL.RepositoryClass
{
    public class MechanicRepository : IMechanicRepository
    {
        private readonly Database.ServiceBookingDBEntities _dbContext;

        public MechanicRepository()
        {
            _dbContext = new Database.ServiceBookingDBEntities();
        }
    }
}
