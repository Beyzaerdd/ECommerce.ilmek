using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ECommerce.Shared.DTOs.ReviewDTOs
{
    public class ReviewDTO
    {
        public int Id { get; set; }
        public int OrderItemId { get; set; }
        public string Content { get; set; }
        public int? Rating { get; set; }
        public int ProductId { get; set; } 
        public string? ProductName { get; set; } 

        public string? ProductImageUrl { get; set; } 

        public DateTime CreatedAt { get; set; }

        public string CustomerName { get; set; }  

  
        public string? CustomerEmail { get; set; }
    }
}
