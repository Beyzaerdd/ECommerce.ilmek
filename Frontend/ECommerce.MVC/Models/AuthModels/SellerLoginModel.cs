using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ECommerce.MVC.Models.AuthModels
{
    public class SellerLoginModel
    {
        [Required, EmailAddress]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [Required, DataType(DataType.Password)]
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
