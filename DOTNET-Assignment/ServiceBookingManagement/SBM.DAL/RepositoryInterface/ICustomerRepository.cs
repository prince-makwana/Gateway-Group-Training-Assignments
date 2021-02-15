using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBM.Models;

namespace SBM.DAL.RepositoryInterface
{
    public interface ICustomerRepository
    {
        string createCustomer(Customers model);
        string updateCustomer(Customers model);
        string deleteCustomer(int id);

        Customers GetCustomerByEmailId(string emailId);
    }
}
