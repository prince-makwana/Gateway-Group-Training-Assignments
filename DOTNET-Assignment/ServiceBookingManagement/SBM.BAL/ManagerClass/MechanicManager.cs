using SBM.DAL.RepositoryInterface;
using SBM.BAL.ManagerInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBM.BAL.ManagerClass
{
    public class MechanicManager : IMechanicManager
    {
        private readonly IMechanicRepository _mechanicRepository;

        public MechanicManager(IMechanicRepository mechanicRepository)
        {
            _mechanicRepository = mechanicRepository;
        }
    }
}
