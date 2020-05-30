
#region " Namespaces "

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace Model
{
    /// <summary>
    /// This class helps in grouping the products based on Category, on this we can perform many filtering operations.
    /// </summary>
    public class Category
    {
        public int CategoryId { get; set; }

        public int CategoryName { get; set; }

        public ICollection<Product> Products { get; set; }

        public ICollection<Category> Categories { get; set; }
    }
}
