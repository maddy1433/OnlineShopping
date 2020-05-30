
#region " Namespaces "

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace Model
{
    /// <summary>
    /// This class helps in providing the detailing of the product like Price, What type of product is this etc.
    /// </summary>
    public class ProductDetail
    {
        [Key]
        public int ProductDetailId { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }

        public int Price { get; set; }

        public string ProductType { get; set; }
    }
}
