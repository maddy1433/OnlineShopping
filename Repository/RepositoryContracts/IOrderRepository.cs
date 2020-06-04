using Model;
using System.Collections.Generic;


namespace Repository.RepositoryContracts
{
    public interface IOrderRepository : IRepository<Order>
    {
        List<Order> GetOrderedProductsBasedonOrderId(int orderId);
        int GetOrderId(int customerId);
        void SaveProducts(int id,List<OrderedProducts> product);

    }
}
