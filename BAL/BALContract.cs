using BAL.BALContracts;
using DAL;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class BALContract : IBALContract
    {
        public IProductBAL productBAL { get; private set; }

        public ICustomerBAL customerBAL { get; private set; }

        public IOrderBAL orderBAL { get; private set; }

        private  IUnitOfWork _unitOfWork;

        public BALContract(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;//Create object and should pass ie:Dependency resolver
            productBAL = new ProductBAL(_unitOfWork);
            customerBAL = new CustomerBAL(_unitOfWork);
            orderBAL = new OrderBAL(_unitOfWork);
        }

        public int Complete()
        {
            return _unitOfWork.Commit();
        }
    }
}
