
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
        [Required]
        public int ProductId { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public string ProductType { get; set; }

        [Required]
        public bool Availability { get; set; }

        [Required]
        public string ImagePath { get; set; }

        //[ForeignKey("Category")]
        [Required]
        public int CategoryId { get; set; }

        //[Required]
        //public Category Category { get; set; }

        //public virtual ICollection<ProductDetail> ProductDetails { get; set; }
    }
}
