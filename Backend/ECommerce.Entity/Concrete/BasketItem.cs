using ECommerce.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Entity.Concrete
{
    public class BasketItem: BaseEntity
    {
        public int BasketId { get; set; } 
        public Basket Basket { get; set; }

        public int ProductId { get; set; } 
        public Product Product { get; set; }

        public int Quantity { get; set; } 

        [NotMapped]
        public decimal TotalPrice => Quantity * (Product?.UnitPrice ?? 0);
    }
}
