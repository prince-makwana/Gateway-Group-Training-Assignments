using SBM.DAL.RepositoryInterface;
using SBM.BAL.ManagerInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBM.BAL.ManagerClass
{
    public class RecordManager : IRecordManager
    {
        private readonly IRecordRepository _recordRepository;

        public RecordManager(IRecordRepository recordRepository)
        {
            _recordRepository = recordRepository;
        }
    }
}
