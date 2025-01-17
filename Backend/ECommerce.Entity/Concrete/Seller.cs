using ECommerce.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Entity.Concrete
{
    public class Seller :ApplicationUser
    {
       

        public int IdentityNumber {  get; set; }
        
        public int WeeklyOrderLimit { get; set; }

    

        public bool IsActive { get; set; }
    }
}
