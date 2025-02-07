using ECommerce.Shared.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Shared.DTOs.BasketDTOs
{
    public class BasketItemCreateDTO
    {

      
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public ProductSize Size { get; set; } 
        public ProductColor Color { get; set; }
    }
}
