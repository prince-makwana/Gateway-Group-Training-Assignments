using SBM.DAL.RepositoryInterface;
using SBM.BAL.ManagerInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBM.Models;

namespace SBM.BAL.ManagerClass
{
    public class DealerManager : IDealerManager
    {
        private readonly IDealerRepository _dealerRepository;

        public DealerManager(IDealerRepository dealerRepository)
        {
            _dealerRepository = dealerRepository;
        }

        public string createDealer(Dealers model)
        {
           return _dealerRepository.createDealer(model);
        }

        public string deleteDealer(int id)
        {
            return _dealerRepository.deleteDealer(id);
        }

        public Dealers GetDealerByEmailId(string emailId)
        {
            return _dealerRepository.GetDealerByEmailId(emailId);
        }

        public string updateDealer(Dealers model)
        {
            return _dealerRepository.updateDealer(model);
        }
    }
}
