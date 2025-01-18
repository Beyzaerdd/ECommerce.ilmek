using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Shared.DTOs
{
    public class ContactMessageCreateDTO
    {
        public string FullName { get; set; } 
        public string Email { get; set; } 
        public string Subject { get; set; } 
        public string Message { get; set; }
    }
}
