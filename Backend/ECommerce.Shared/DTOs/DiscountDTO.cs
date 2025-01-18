using ECommerce.Shared.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Shared.DTOs
{
    public class DiscountDTO
    {
        public int Id { get; set; } 
        public string Name { get; set; } 
        public decimal DiscountValue { get; set; }
        public DiscountType Type { get; set; } 
        public string CouponCode { get; set; } 
        public string ApplicationUserId { get; set; }
        public string ApplicationUserName { get; set; } 
        public DateTime StartDate { get; set; } 
        public DateTime EndDate { get; set; } 
        public bool IsActive { get; set; }
    }
}
