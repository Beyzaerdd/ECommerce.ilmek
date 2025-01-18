using ECommerce.Shared.ComplexTypes;
using ECommerce.Shared.DTOs.InvoiceDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Shared.DTOs.OrderDTOs
{
    public class OrderCreateDTO
    {
        public string ApplicationUserId { get; set; }

        public DateTime OrderDate { get; set; }
        public IEnumerable<OrderItemCreateDTO> OrderItems { get; set; } = new List<OrderItemCreateDTO>();
        public InvoiceCreateDTO Invoice { get; set; }

    }
}
