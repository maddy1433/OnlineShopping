using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.BALContracts
{
    public interface ICustomerBAL
    {
        Customer GetCustomerDetailsByID(int id);
    }
}
