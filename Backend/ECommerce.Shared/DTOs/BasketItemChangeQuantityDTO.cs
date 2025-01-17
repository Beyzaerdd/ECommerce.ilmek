using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Shared.DTOs
{
    public class BasketItemChangeQuantityDTO
    {
        public int BasketItemId { get; set; }
        public int Quantity { get; set; }
    }
}
