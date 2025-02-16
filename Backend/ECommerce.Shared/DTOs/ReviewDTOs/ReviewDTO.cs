﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Shared.DTOs.ReviewDTOs
{
    public class ReviewDTO
    {
        public int Id { get; set; }
        public int OrderItemId { get; set; }
        public string Content { get; set; }
        public int? Rating { get; set; }
        public int ProductId { get; set; } // Ürünün ID'si
        public string ProductName { get; set; } // Ürünün adı



        public DateTime CreatedAt { get; set; }
    }
}
