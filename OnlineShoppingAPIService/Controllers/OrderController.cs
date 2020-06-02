using BAL;
using BAL.BALContracts;
using DepenencyResolver;
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

        // GET: api/Order/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Order
        public void Post([FromBody]string value)
        {
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
