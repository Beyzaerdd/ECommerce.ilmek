using ECommerce.Entity.Abstract;
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
    
        public class Product : BaseEntity

    { 

        public string Name { get; set; } 

        public string Description { get; set; } 
  
        public decimal UnitPrice { get; set; } 
     
       
    
        public int PreparationTimeInDays { get; set; } 
        public bool IsActive { get; set; } 

  
        [MinLength(1, ErrorMessage = "At least one category is required.")]
       
        public int CategoryId { get; set; }
        public Category Category { get; set; }
     

        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }


        public List<ProductSize> AvailableSizes { get; set; }
        public List<ProductColor> AvailableColors { get; set; }

        public ICollection<UserFav> UserFavs { get; set; } 
        public ICollection<OrderItem> OrderItems { get; set; }
        public ICollection<BasketItem> BasketItems { get; set; }

        public ICollection<Discount> Discounts { get; set; }

        public string ImageUrl { get; set; }


    }





    }

