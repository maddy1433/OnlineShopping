using BAL.BALContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.BALContracts
{
    public interface IBALContract
    {
        IProductBAL productBAL { get; }
        ICustomerBAL customerBAL { get; }
        IOrderBAL orderBAL { get; }
        int Complete();
    }
}
