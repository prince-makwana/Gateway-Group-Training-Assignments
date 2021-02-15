using SBM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBM.BAL.ManagerInterface
{
    public interface IAccountManager
    {
        bool loginAccount(UserLogin model);
    }
}
