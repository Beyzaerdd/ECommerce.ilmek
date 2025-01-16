﻿using ECommerce.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Shared.ComplexTypes;

namespace ECommerce.Entity.Concrete
{
   public class Discount : BaseEntity<int>
    {
      
           
            public string Name { get; set; } 
            public decimal DiscountValue { get; set; }
            public DiscountType Type { get; set; } 
         
            public string CouponCode { get; set; } 
            public string SellerId { get; set; } 
            public Seller Seller { get; set; } 
            public DateTime StartDate { get; set; } 
            public DateTime EndDate { get; set; } 
            public bool IsActive { get; set; } 
        }


    
}
