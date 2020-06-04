using BAL;
using BAL.BALContracts;
using DepenencyResolver;
using Model;
using Model.ViewModel;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OnlineShoppingAPIService.Controllers
{
    public class OrderController : ApiController
    {
        IOrderBAL _orderBAL;
        IUnitOfWork _unitOfWork;
        public OrderController()
        {
            _unitOfWork = new DependencyResolver().CreateUoWInstance();
            _orderBAL = new OrderBAL(_unitOfWork);
        }

        // GET: api/Order
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        //getbycustomerId
        public IHttpActionResult GetOrdersByCustomerId(int id)
       // public List<Order> GetOrdersByCustomerId(int id)
        {
            return Ok(_orderBAL.GetOrdersByCustomerId(id).ToList());
        }

        // GET: api/Order/5
        public List<Order> GetOrdersByOrderId(int id)
        {
            return _orderBAL.GetProductsForOrderId(id).ToList();
        }

        // POST: api/Order
        public void Post([FromBody]BookOrder bookOrder)
        {
            _orderBAL.BookNewOrder(bookOrder);
        }

        // PUT: api/Order/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Order/5
        public void Delete(int id)
        {
        }
    }
}
