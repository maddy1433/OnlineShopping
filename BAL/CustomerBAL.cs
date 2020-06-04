using BAL.BALContracts;
using Model;
using Repository;
using Repository.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class CustomerBAL : ICustomerBAL
    {
        IUnitOfWork unitOfWork;
        ICustomerRepository _customerRepository;

        public CustomerBAL(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            _customerRepository = unitOfWork.Customer;
        }

        public bool DeleteCustomer(int id)
        {
            var customerInDb = _customerRepository.GetById(id);
            if (customerInDb != null)
            {
                _customerRepository.Delete(customerInDb);
                unitOfWork.Commit();
                return true;
            }
            return false;
        }

        public IQueryable<Customer> GetAllCustomers()
        {
            return _customerRepository.GetAll().AsQueryable<Customer>();
        }

        public Customer GetCustomersByID(int id)
        {
            return _customerRepository.GetById(id);
        }

        public int SaveOrUpdateCustomer(int id,Customer customer)
        {
            if (customer != null)
            {
                var _customerInDb = (customer.CustomerID != 0) ? _customerRepository.GetById(id) : new Customer();
                _customerInDb.FirstName = customer.FirstName;
                _customerInDb.LastName = customer.LastName;
                _customerInDb.Phone = customer.Phone;
                _customerInDb.Email = customer.Email;
                if (customer.CustomerID == 0)
                    _customerRepository.Add(_customerInDb);
                else
                    _customerRepository.Update(_customerInDb);
                return unitOfWork.Commit();
            }
            return 0;
        }
    }
}
