using ECommerce.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Entity.Concrete
{
    public class Basket :BaseEntity
    {
        public string UserId { get; set; }
        public NormalUser User { get; set; }

        
        public ICollection<BasketItem> BasketItems { get; set; }

    }
}
