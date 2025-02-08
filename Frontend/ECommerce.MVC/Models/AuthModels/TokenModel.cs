using System.Text.Json.Serialization;

namespace ECommerce.MVC.Models.AuthModels
{
    public class TokenModel
    {
        [JsonPropertyName("accesstoken")]
        public string AccessToken { get; set; }

        [JsonPropertyName("expirationdate")]
        public DateTime ExpirationDate { get; set; }
    }
}
