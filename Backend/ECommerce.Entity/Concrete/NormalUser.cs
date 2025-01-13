using ECommerce.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Entity.Concrete
{
    public class NormalUser :ApplicationUser


    {
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }
        public ICollection<Order> Orders { get; set; } 
        public ICollection<UserFav> UserFavs { get; set; }
        public int BasketId { get; set; }
        public Basket Basket { get; set; } 
        
        public ICollection<ContactMessage> ContactMessages { get; set; }
    }
}
