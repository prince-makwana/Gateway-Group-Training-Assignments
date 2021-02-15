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
    public class CustomerManager : ICustomerManager
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerManager(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public string createCustomer(Customers model)
        {
            return _customerRepository.createCustomer(model);
        }

        public string deleteCustomer(int id)
        {
            return _customerRepository.deleteCustomer(id);
        }

        public Customers GetCustomerByEmailId(string emailId)
        {
            return _customerRepository.GetCustomerByEmailId(emailId);
        }

        public string updateCustomer(Customers model)
        {
            return _customerRepository.updateCustomer(model);
        }
    }
}
