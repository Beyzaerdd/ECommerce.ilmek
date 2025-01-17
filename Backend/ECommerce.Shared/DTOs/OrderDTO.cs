using ECommerce.Shared.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Shared.DTOs
{
    public class OrderDTO
    {
        public string Id { get; set; }
        public string ApplicationUserId { get; set; }
        public string ApplicationUserName { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderCreateDTO> OrderItems { get; set; } = new List<OrderCreateDTO>();
        public InvoiceDTO Invoice { get; set; }
        public decimal TotalPrice => OrderItems?.Sum(oi => oi.TotalPrice) ?? 0;
    }
}