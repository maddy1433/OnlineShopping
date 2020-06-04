using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    public class BookOrder
    {
        public Order Order { get; set; }
        public List<OrderedProducts> Products { get; set; }
    }
}
