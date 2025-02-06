using System.ComponentModel.DataAnnotations;

namespace ECommerce.MVC.Models.AuthModels
{
    public class SellerRegisterModel
    {
        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Country { get; set; }

        [Required, Phone]
        public string PhoneNumber { get; set; }

        [Required, DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Kimlik numarası 11 haneli olmalıdır.")]
        public string IdentityNumber { get; set; }

        [Required]
        public string StoreName { get; set; }
    }
}
