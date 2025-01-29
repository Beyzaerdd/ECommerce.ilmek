using ECommerce.Shared.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Shared.DTOs.UserFavDTOs
{
    public class UserFavDTO
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public string ApplicationUserFullName { get; set; }
        public int? ProductId { get; set; }
        public ProductDTO Product { get; set; }

    }
}
