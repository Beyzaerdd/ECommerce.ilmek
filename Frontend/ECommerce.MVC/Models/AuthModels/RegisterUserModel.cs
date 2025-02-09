using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ECommerce.MVC.Models.AuthModels
{
    public class RegisterUserModel
    {
        [Required]
        [JsonPropertyName("firstname")]
        public string FirstName { get; set; }

        [Required]
        [JsonPropertyName("lastname")]
        public string LastName { get; set; }

        [Required]
        [JsonPropertyName("city")]
        public string City { get; set; }

        [Required]
        [JsonPropertyName("address")]
        public string Address { get; set; }

        [Required]
        [JsonPropertyName("country")]
        public string Country { get; set; }

        [Required, EmailAddress]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [Required, DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakter olmalıdır.")]
        [JsonPropertyName("password")]
        public string Password { get; set; }

        [Required, DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Şifreler eşleşmiyor.")]
        [JsonPropertyName("confirmpassword")]
        public string ConfirmPassword { get; set; }

        [Required, Phone]
        [JsonPropertyName("phonenumber")]
        public string PhoneNumber { get; set; }
    }
}
