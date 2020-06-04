using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.BALContracts
{
    public interface ICustomerBAL
    {
        Customer GetCustomersByID(int id);
        IQueryable<Customer> GetAllCustomers();
        int SaveOrUpdateCustomer(int id,Customer customer);
        bool DeleteCustomer(int id);
    }
}
