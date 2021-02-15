using SBM.BAL.ManagerInterface;
using SBM.DAL.RepositoryInterface;
using SBM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBM.BAL.ManagerClass
{
    public class AccountManager : IAccountManager
    {
        private readonly IAccountRepository _accountRepository;

        public AccountManager(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public bool loginAccount(UserLogin model)
        {
            return _accountRepository.loginAccount(model);
        }
    }
}
