#region Description of OrderedProducts
/*
 * For every Order we have a list of Orderedproducts
 * Each product have its details in products table which can be fetched using ProductID
 * Each product listed in an order must have a quantity to calculate the prices
 * */
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class OrderedProducts
    {
        [Required]
        public int OrderedProductsID { get; set; }

        [Required]
        public int ProductID { get; set; }

        [Required]
        public int Quantity { get; set; }
        
        /*Based on the productID the info is available in this object*/
        public Product Product { get; set; }
    }
}
