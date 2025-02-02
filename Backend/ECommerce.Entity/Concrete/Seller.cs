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
       

        public string  IdentityNumber {  get; set; }
        
        public int WeeklyOrderLimit { get; set; }

        public string StoreName { get; set; }

        public bool IsActive { get; set; } = true;
        public bool IsApproved { get; set; } = false;
    }
}
