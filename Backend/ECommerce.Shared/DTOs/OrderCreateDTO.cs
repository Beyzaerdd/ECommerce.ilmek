using ECommerce.Shared.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Shared.DTOs
{
    public class OrderCreateDTO
    {
        public string ApplicationUserId { get; set; }
    
        public DateTime OrderDate { get; set; }
        public IEnumerable<OrderItemCreateDTO> OrderItems { get; set; } = new List<OrderItemCreateDTO>();
        public InvoiceCreateDTO Invoice { get; set; }
        public decimal TotalAmount => OrderItems.Sum(item => item.UnitPrice * item.Quantity);
    }
}
