using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Shared.DTOs
{
    public  class BasketDTO
    {
        public string ApplicationUserId { get; set; }
        public ApplicationUserDTO ApplicationUser { get; set; }


        public ICollection<BasketItemDTO> BasketItems { get; set; }
    }
}
