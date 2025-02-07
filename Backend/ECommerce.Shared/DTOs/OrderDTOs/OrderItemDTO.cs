using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Shared.ComplexTypes;
using ECommerce.Shared.DTOs.ProductDTOs;
using ECommerce.Shared.DTOs.ReviewDTOs;

namespace ECommerce.Shared.DTOs.OrderDTOs
{
    public class OrderItemDTO
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public ProductDTO Product { get; set; }

        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public List<ReviewDTO> Reviews { get; set; }
        public ProductSize Size { get; set; } 
        public ProductColor Color { get; set; }
    }
}
