using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Entity.Concrete
{
    public class ApplicationUser : IdentityUser
    {
      
        public string FirstName { get; set; }
      
        public string LastName { get; set; }
  
        public string Address { get; set; }
        public string City { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime DateOfBirth { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<UserFav> UserFavs { get; set; }
        public ICollection<ContactMessage> ContactMessages { get; set; }
        public int? BasketId { get; set; }
        public Basket Basket { get; set; }
        public ICollection<Product> Products { get; set; }

        public ICollection<Discount> Discounts { get; set; }



    }
}
