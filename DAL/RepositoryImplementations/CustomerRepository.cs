#region " Namespaces "

using Model;
using Repository.RepositoryContracts;
using System;

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

        public Customer GetCustomerById(int id)
        {
            throw new NotImplementedException();
        }
    }
}