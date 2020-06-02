#region " Namespaces "

using Model;
using Repository.RepositoryContracts;
using System;
using System.Data.Entity;
using System.Data;
using System.Linq;

#endregion

namespace DAL.RepositoryImplementations
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private ShoppingModel _context;
        public CustomerRepository(ShoppingModel dataContext)
            : base(dataContext)
        {
            _context = dataContext;
        }

        public ShoppingModel Context
        {
            get { return _context as ShoppingModel; }
        }

        public Customer GetCustomerDetailsById(int id)
        {
            var customerdetails = _context.Customers.SingleOrDefault(c => c.CustomerID == id);
            return customerdetails;
        }
    }
}