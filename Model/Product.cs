
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
    /// This class is used to Create Products entity in database which is used to do CRUD operations for Products.
    /// </summary>
    /// 
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductType { get; set; }

        public bool Availability { get; set; }

        public string ImagePath { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public virtual ICollection<ProductDetail> ProductDetails { get; set; }
    }
}
