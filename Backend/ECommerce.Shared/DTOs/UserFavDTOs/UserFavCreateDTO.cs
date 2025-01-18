using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Shared.DTOs.UserFavDTOs
{
    public class UserFavCreateDTO
    {
        public string ApplicationUserId { get; set; }
        public int? ProductId { get; set; }
    }
}
