using ECommerce.Shared.ComplexTypes;
using System.Text.Json.Serialization;

namespace ECommerce.MVC.Areas.Admin.Models.DiscountModels
{
    public class DiscountUpdateModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("discountValue")]
        public decimal DiscountValue { get; set; }
        [JsonPropertyName("type")]
        public DiscountType Type { get; set; }
        [JsonPropertyName("couponCode")]
        public string CouponCode { get; set; }
        [JsonPropertyName("startDate")]
        public DateTime StartDate { get; set; }
        [JsonPropertyName("endDate")]
        public DateTime EndDate { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }
      
    }
}
