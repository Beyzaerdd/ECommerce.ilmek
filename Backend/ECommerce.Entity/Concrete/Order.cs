using ECommerce.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Shared.ComplexTypes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Entity.Concrete
{
    public class Order : BaseEntity<int>
    {
        public string UserId { get; set; }
        public NormalUser User { get; set; }
        [Required]
        public OrderStatus Status { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "An order must have at least one item.")]
        public ICollection<OrderItem> OrderItems { get; set; }
        [Required]
        public Invoice Invoice { get; set; }
        [NotMapped]
        public decimal TotalPrice => OrderItems?.Sum(oi => oi.TotalPrice) ?? 0; // Siparişin toplam fiyatı





    }
}
