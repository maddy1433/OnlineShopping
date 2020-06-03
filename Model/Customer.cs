#region Description of Customer class
/* Customer must have a default address
 * Lazy loads, Customer can have Zero/multiple shipping address
 * Lazy loads, Customer can have Zero/multiple Orderes placed
 * */
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Customer
    {
        [Required]
        [Key]
        public int CustomerID { get; set; }
        
        [Required]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        [Required]
        public string Email { get; set; }

    }

    
}
