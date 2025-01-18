using ECommerce.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Entity.Concrete
{
    public class Review :BaseEntity
    {
        public int OrderItemId { get; set; } 
        public OrderItem OrderItem { get; set; }

     
        public string Content { get; set; } 
        public int? Rating { get; set; } 
        public bool? IsApproved { get; set; } 
      
    }
}
