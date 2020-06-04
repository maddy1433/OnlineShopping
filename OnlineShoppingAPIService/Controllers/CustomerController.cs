using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BAL.BALContracts;
using Model;
using DAL;
using DepenencyResolver;
using Repository;
using BAL;

namespace OnlineShoppingAPIService.Controllers
{
    public class CustomerController : ApiController
    {
        /* Exposing the BAL contracts only
         * Access DAL object using the BAL contracts here 
         * IBALContract bALContracts; //INITIALIZATION
         * bALContracts.customerBAL = new CustomerBAL(_unitOfWork); //constructor invoking object
         */

        //ICustomerBAL _customerBAL;
        IUnitOfWork _unitOfWork;

        IBALContract bALContracts;
        public CustomerController()
        {
            
            _unitOfWork = new DependencyResolver().CreateUoWInstance();
            //_customerBAL = new CustomerBAL(_unitOfWork);
            bALContracts = new BALContract(_unitOfWork);
        }

        // GET: api/Customer
        public IEnumerable<Customer> Get()
        {
            return bALContracts.customerBAL.GetAllCustomers().AsEnumerable();
        }

        // GET: api/Customer/5
        public Customer Get(int id)
        {
            var customer = bALContracts.customerBAL.GetCustomersByID(id);
            return customer;
            //return "value";
        }

        // POST: api/Customer
        public void Post([FromBody]Customer customer)
        {
            bALContracts.customerBAL.SaveOrUpdateCustomer(customer.CustomerID,customer);
        }

        // PUT: api/Customer/5
        public void Put(int id, [FromBody]Customer customer)
        {
            bALContracts.customerBAL.SaveOrUpdateCustomer(id,customer);
        }

        // DELETE: api/Customer/5
        public void Delete(int id)
        {
            bALContracts.customerBAL.DeleteCustomer(id);
        }
    }
}
