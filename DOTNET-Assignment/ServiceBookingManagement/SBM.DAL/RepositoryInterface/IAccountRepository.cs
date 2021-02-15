using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBM.Models;

namespace SBM.DAL.RepositoryInterface
{
    public interface IAccountRepository
    {
        bool loginAccount(UserLogin model);
    }
}
