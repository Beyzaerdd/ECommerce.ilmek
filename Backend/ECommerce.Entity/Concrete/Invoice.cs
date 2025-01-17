using ECommerce.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Entity.Concrete
{
    public class Invoice : BaseEntity
    {
        
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
      
        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }
     
        public string PostalCode { get; set; }

        public string PhoneNumber { get; set; }
      
        public string Email { get; set; }
    }
}
