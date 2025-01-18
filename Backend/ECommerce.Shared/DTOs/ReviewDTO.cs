﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Shared.DTOs
{
    public class ReviewDTO
    {
        public int Id { get; set; }
        public int OrderItemId { get; set; }
        public string Content { get; set; }
        public int? Rating { get; set; } 
        public bool? IsApproved { get; set; } 
        public string OrderItemProductName { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
