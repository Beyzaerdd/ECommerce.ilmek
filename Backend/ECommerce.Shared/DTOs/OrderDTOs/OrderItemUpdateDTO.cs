﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Shared.DTOs.ReviewDTOs;

namespace ECommerce.Shared.DTOs.OrderDTOs
{
    public class OrderItemUpdateDTO
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }

        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
      
        public List<ReviewDTO> Reviews { get; set; }
    }
}
