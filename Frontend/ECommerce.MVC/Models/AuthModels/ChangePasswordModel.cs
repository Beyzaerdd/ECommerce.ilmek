
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace ECommerce.MVC.Models.AuthModels
{
    public class ChangePasswordModel
    {
        [Required, EmailAddress]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [Required, DataType(DataType.Password)]
        [JsonPropertyName("currentpassword")]
        public string CurrentPassword { get; set; }

        [Required, DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Yeni şifre en az 6 karakter olmalıdır.")]
        [JsonPropertyName("newpassword")]
        public string NewPassword { get; set; }

        [Required, DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Yeni şifreler eşleşmiyor.")]
        [JsonPropertyName("confirmnewpassword")]
        public string ConfirmNewPassword { get; set; }

    }
}
