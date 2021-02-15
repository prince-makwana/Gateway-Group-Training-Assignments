using SBM.BAL.ManagerInterface;
using SBM.DAL.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBM.BAL.ManagerClass
{
    public class JobCardManager : IJobCardManager
    {
        private readonly IJobCardRepository _jobCardRepository;

        public JobCardManager(IJobCardRepository jobCardRepository)
        {
            _jobCardRepository = jobCardRepository;
        }
    }
}
