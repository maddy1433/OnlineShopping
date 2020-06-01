using Model;
using System.Collections.Generic;


namespace Repository.RepositoryContracts
{
    public interface IOrderRepository : IRepository<Order>
    {
        List<Order> GetOrders();
    }
}
