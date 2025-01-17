using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Shared.DTOs
{
    public class BasketItemRemoveDTO
    {
        public int BasketId { get; set; }
        public int ProductId { get; set; }
    }
}
