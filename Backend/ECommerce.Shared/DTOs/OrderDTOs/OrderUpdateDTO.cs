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
       
    }
}
