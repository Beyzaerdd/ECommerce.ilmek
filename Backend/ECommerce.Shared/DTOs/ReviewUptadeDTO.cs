using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Shared.DTOs
{
    public class ReviewUptadeDTO
    {
        public int Id { get; set; } 
        public string Content { get; set; } 
        public int? Rating { get; set; } 
        public bool? IsApproved { get; set; }
    }
}
