﻿using ECommerce.Entity.Abstract;
using ECommerce.Shared.ComplexTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ECommerce.Entity.Concrete
{
    [DebuggerDisplay("{Name}")]
        public class Product : BaseEntity<int>

    { 

        public string Name { get; set; } 

        public string Description { get; set; } 
  
        public decimal Price { get; set; } 
     
        public ProductSize Size { get; set; } 
  
        public ProductColor Color { get; set; } 
    
        public int PreparationTimeInDays { get; set; } 
        public bool IsActive { get; set; } 

  
        [MinLength(1, ErrorMessage = "At least one category is required.")]
       
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        
        public string SellerId { get; set; }
        public Seller Seller { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<UserFav> UserFavs { get; set; } 
        public ICollection<OrderItem> OrderItems { get; set; }
        public ICollection<BasketItem> BasketItems { get; set; }

        public ICollection<Discount> Discounts { get; set; }

       

    }





    }
