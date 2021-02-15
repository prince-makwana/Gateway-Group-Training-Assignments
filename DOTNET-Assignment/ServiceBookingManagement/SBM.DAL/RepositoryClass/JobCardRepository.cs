using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBM.DAL.RepositoryInterface;

namespace SBM.DAL.RepositoryClass
{
    public class JobCardRepository : IJobCardRepository
    {
        private readonly Database.ServiceBookingDBEntities _dbContext;

        public JobCardRepository()
        {
            _dbContext = new Database.ServiceBookingDBEntities();
        }
    }
}
