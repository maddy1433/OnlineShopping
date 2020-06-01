using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class CustomerAddress
    {
        [Required]
        public int CustomerAddressID { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Country { get; set; }

        public string State { get; set; }

        [Required]
        public string Postalcode { get; set; }
    }
}
