using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ECommerce.MVC.Models.AuthModels
{
    public class SellerRegisterModel
    {
        [Required, EmailAddress]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [Required]
        [JsonPropertyName("firstname")]
        public string FirstName { get; set; }

        [Required]
        [JsonPropertyName("lastname")]
        public string LastName { get; set; }

        [Required, DataType(DataType.Password)]
        [JsonPropertyName("password")]
        public string Password { get; set; }

        [Required]
        [JsonPropertyName("address")]
        public string Address { get; set; }

        [Required]
        [JsonPropertyName("city")]
        public string City { get; set; }

        [Required]
        [JsonPropertyName("country")]
        public string Country { get; set; }

        [Required, Phone]
        [JsonPropertyName("phonenumber")]
        public string PhoneNumber { get; set; }

        [Required, DataType(DataType.Date)]
        [JsonPropertyName("dateofbirth")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Kimlik numarası 11 haneli olmalıdır.")]
        [JsonPropertyName("identitynumber")]
        public string IdentityNumber { get; set; }

        [Required]
        [JsonPropertyName("storename")]
        public string StoreName { get; set; }
    }
}
