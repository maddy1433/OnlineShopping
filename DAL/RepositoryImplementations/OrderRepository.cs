#region " Namespace "

using Model;
using Repository.RepositoryContracts;
using System;
using System.Collections.Generic;

#endregion

namespace DAL.RepositoryImplementations
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private ShoppingModel _context;

        public OrderRepository(ShoppingModel dataContext)
            : base(dataContext)
        {
            _context = dataContext;
        }

        public ShoppingModel Context
        {
            get { return _context as ShoppingModel; }
        }

        public List<Order> GetOrders()
        {
            throw new NotImplementedException();
        }
    }

   
}
