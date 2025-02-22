using ECommerce.MVC.Models.UserModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ECommerce.MVC.Models.BasketModels
{
    public class BasketModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [Required]
        [JsonPropertyName("applicationUserId")]
        public string ApplicationUserId { get; set; }

        [JsonPropertyName("applicationUser")]
        public ApplicationUserModel ApplicationUser { get; set; }

        [JsonPropertyName("basketItems")]
        public IEnumerable<BasketItemModel> BasketItems { get; set; } = new List<BasketItemModel>();

        [StringLength(20, ErrorMessage = "Kupon kodu en fazla 20 karakter olabilir.")]
        [JsonPropertyName("couponCode")]
        public string? CouponCode { get; set; }



    }
}
