using ECommerce.MVC.Models.ProductModels;
using ECommerce.Shared.DTOs.ProductDTOs;
using System.Text.Json.Serialization;

namespace ECommerce.MVC.Models.UserFavModels
{
    public class UserFavModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("applicationUserId")]
        public string ApplicationUserId { get; set; }

        [JsonPropertyName("applicationUserFullName")]
        public string ApplicationUserFullName { get; set; }

        [JsonPropertyName("productId")]
        public int? ProductId { get; set; }

        [JsonPropertyName("product")]
        public ProductModel Product { get; set; }
    }
}
