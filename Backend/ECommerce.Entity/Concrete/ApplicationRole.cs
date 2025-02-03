using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Entity.Concrete
{
    public class ApplicationRole : IdentityRole
    {
        public string Description { get; set; } 
        public DateTime CreatedDate { get; set; } = DateTime.Now; 
        public DateTime? UpdatedDate { get; set; } 
        public bool IsActive { get; set; } = true; 
    }
}
