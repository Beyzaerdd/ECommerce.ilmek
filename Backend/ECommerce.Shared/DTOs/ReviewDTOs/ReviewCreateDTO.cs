using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Shared.DTOs.ReviewDTOs
{
    public class ReviewCreateDTO
    {
        public int OrderItemId { get; set; }
        public string Content { get; set; }
        public int? Rating { get; set; }
   
    }
}
