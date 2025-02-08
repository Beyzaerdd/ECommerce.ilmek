using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ECommerce.MVC.Models.AuthModels
{
    public class ForgotPasswordModel
    {
        [Required, EmailAddress]
        [JsonPropertyName("email")]
        public string Email { get; set; }
    }
}
