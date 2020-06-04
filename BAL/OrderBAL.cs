using BAL.BALContracts;
using Model;
using Model.ViewModel;
using Repository;
using Repository.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class OrderBAL : IOrderBAL
    {
        IUnitOfWork unitOfWork;
        IOrderRepository _orderRepository;

        public OrderBAL(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            _orderRepository = unitOfWork.Order;
        }

        public int BookNewOrder(BookOrder newOrder)
        {
            if(newOrder != null)
            {
                Order order = new Order
                {
                    CustomerId = newOrder.Order.CustomerId,//dynamic customer id
                    DeliveryAddress = newOrder.Order.DeliveryAddress,
                    DeliveryDate = newOrder.Order.DeliveryDate,
                    OrderDate = newOrder.Order.OrderDate,
                    TotalSale = newOrder.Order.TotalSale
                };
                _orderRepository.Add(order);
                unitOfWork.Commit();
               var newOrderId = _orderRepository.GetOrderId(order.CustomerId);
                _orderRepository.SaveProducts(newOrderId, newOrder.Products);
                return 1;
            }
            return 0;
        }
       /* private int BookOrder(int newOrderId, List<OrderedProducts> order)
        {
            if(order != null)
            {
                foreach(var product in order)
                {
                    OrderedProducts orderedProduct = new OrderedProducts();
                    orderedProduct.ProductID = product.ProductID;
                    orderedProduct.Quantity = product.Quantity;
                    orderedProduct.OrderId = newOrderId;
                    _orderRepository.SaveProducts(orderedProduct);
                }
            }
            return 0;
        }*/

        public List<Order> GetOrdersByCustomerId(int id)
        {
            var OrderOfCustomer = _orderRepository.GetAll().Where(o => o.CustomerId == id).ToList();
            return OrderOfCustomer;
        }

        public List<Order> GetProductsForOrderId(int id)
        {
            var ProductListBasedOnOrderId = _orderRepository.GetOrderedProductsBasedonOrderId(id);
            return ProductListBasedOnOrderId;
        }

       
    }
}
