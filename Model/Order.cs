using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Order
    {
        [Required]
        public int OrderID { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        public DateTime DeliveryDate { get; set; }

        [Required]
        public string DeliveryAddress { get; set; }

        public decimal TotalSale { get; set; }

        [ForeignKey("OrderedProducts")]
        public int OrderedProductsID { get; set; }
        
        /*On clicking OrderID, it lazy loads the detail of the particular order*/
        public virtual ICollection<OrderedProducts> OrderedProducts { get; set; }
    }
}
