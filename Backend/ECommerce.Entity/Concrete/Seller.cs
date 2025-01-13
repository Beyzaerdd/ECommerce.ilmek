using ECommerce.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Entity.Concrete
{
    public class Seller :ApplicationUser
    {
        
        public int IdentityNumber {  get; set; }
        
        public int WeeklyOrderLimit { get; set; }
       
        public ICollection<Product> Products { get; set; }

        public ICollection<Discount> Discounts { get; set; }

      
        public bool IsActive { get; set; }
    }
}
