using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Shared.DTOs.UserDTO
{
    public class UpdateSellerProfileDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string StoreName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public bool IsActive { get; set; }

        public int WeeklyOrderLimit { get; set; }
    }
}
