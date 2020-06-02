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

        public Customer GetCustomerDetailsByID(int id)
        {
            return _customerRepository.GetCustomerDetailsById(id);             
        }
    }
}
