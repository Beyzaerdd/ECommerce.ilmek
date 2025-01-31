using ECommerce.Shared.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Shared.DTOs.OrderDTOs
{
    public class OrderUpdateDTO
    {
        public OrderStatus Status { get; set; }
        public List<OrderItemUpdateDTO> OrderItems { get; set; } = new List<OrderItemUpdateDTO>();

        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

    }
}
