using BAL.BALContracts;
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
    }
}
