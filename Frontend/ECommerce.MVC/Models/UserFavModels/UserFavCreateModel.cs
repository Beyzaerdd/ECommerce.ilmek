using System.Text.Json.Serialization;

namespace ECommerce.MVC.Models.UserFavModels
{
    public class UserFavCreateModel
    {
        [JsonPropertyName("productId")]
        public int? ProductId { get; set; }
    }
}
