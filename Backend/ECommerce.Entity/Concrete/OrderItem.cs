using ECommerce.Entity.Abstract;
using ECommerce.Shared.ComplexTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Entity.Concrete
{
    public class OrderItem: BaseEntity
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public ProductSize Size { get; set; }
        public ProductColor Color { get; set; }
        public ICollection<Review> Reviews { get; set; }

        [NotMapped]
        public decimal TotalPrice { get; set; }
        
    }
}
