using ECommerce.Shared.ComplexTypes;
using System.Text.Json.Serialization;

namespace ECommerce.MVC.Models.DiscountModels
{
    public class DiscountModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("discountValue")] 
        public decimal DiscountValue { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }


        [JsonPropertyName("type")]
        public DiscountType Type { get; set; }
        [JsonPropertyName("couponCode")]
        public string CouponCode { get; set; }
        [JsonPropertyName("startDate")]
        public DateTime StartDate { get; set; }
        [JsonPropertyName("endDate")]
        public DateTime EndDate { get; set; }


    } 

}
