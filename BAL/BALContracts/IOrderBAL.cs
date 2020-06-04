using Model;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.BALContracts
{
    public interface IOrderBAL
    {
        List<Order> GetOrdersByCustomerId(int customerId);
        List<Order> GetProductsForOrderId(int OrderId);
        int BookNewOrder(BookOrder newOrder);
        //bool DeleteCustomer(int id);
    }
}
