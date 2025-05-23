﻿using ECommerce.Shared.ComplexTypes;
using ECommerce.Shared.DTOs.EnumDTOs;
using ECommerce.Shared.DTOs.InvoiceDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Shared.DTOs.OrderDTOs
{
    public class OrderDTO
    {
        public string Id { get; set; }
        public string ApplicationUserId { get; set; }
        public string ApplicationUserName { get; set; }

        public string ApplicationUserEmail { get; set; } 
        public string ApplicationUserPhoneNumber { get; set; }

        public string ApplicationUserAdress { get; set; } 
        public EnumDTO Status { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderItemDTO> OrderItems { get; set; } = new List<OrderItemDTO>();
      
        public decimal TotalPrice {  get; set; }

        public string OrderNumber { get; set; }
    }
}