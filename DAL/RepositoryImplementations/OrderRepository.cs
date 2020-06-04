#region " Namespace "

using Model;
using Repository.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

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

       public int GetOrderId(int customerId)
        {
            int id = (from x in _context.Orders
                     where (x.CustomerId == customerId)
                     orderby x.CustomerId descending
                     select x.CustomerId).FirstOrDefault();
            return id;
        }

        public List<Order> GetOrderedProductsBasedonOrderId(int orderId)
        {
            return _context.Orders.Include(x => x.OrderedProducts).Where(o => o.OrderID == orderId).ToList();
        }

        public void SaveProducts(int id,List<OrderedProducts> products)
        {
            foreach(var product in products)
            {
                product.OrderId = id;
                _context.OrderedProducts.Add(product);
            }
            _context.SaveChanges();
        }
    }

   
}
