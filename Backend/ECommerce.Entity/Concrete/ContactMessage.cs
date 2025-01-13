using ECommerce.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Entity.Concrete
{
    public class ContactMessage :BaseEntity
    {
        
    
        public string FullName { get; set; }
     
       
        public string Email { get; set; }
    
        public string Subject { get; set; }
       
        public string Message { get; set; }
        public string? UserId { get; set; }
        public NormalUser User { get; set; }
   
    }
}
