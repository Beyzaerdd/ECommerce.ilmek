using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Shared.ComplexTypes;
using ECommerce.Shared.DTOs.ProductDTOs;

namespace ECommerce.Shared.DTOs.BasketDTOs
{
    public class BasketItemDTO
    {
        public int Id { get; set; }
        public int BasketId { get; set; }
        public int ProductId { get; set; }
        public ProductDTO Product { get; set; }
        public int Quantity { get; set; }
        public ProductSize Size { get; set; }
        public ProductColor Color { get; set; }

        public decimal OriginalPrice { get; set; }
        public decimal DiscountedPrice {get;set;}

       
    }
}
