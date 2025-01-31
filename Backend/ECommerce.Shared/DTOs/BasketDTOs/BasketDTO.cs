using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Shared.DTOs.UsersDTO;

namespace ECommerce.Shared.DTOs.BasketDTOs
{
    public class BasketDTO
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUserDTO ApplicationUser { get; set; }
        public IEnumerable<BasketItemDTO> BasketItems { get; set; } = new List<BasketItemDTO>();
        public string? CouponCode { get; set; }
    }
}
