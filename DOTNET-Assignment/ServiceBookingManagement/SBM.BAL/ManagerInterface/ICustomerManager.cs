using SBM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBM.BAL.ManagerInterface
{
    public interface ICustomerManager
    {
        string createCustomer(Customers model);
        string updateCustomer(Customers model);
        string deleteCustomer(int id);

        Customers GetCustomerByEmailId(string emailId);
    }
}
