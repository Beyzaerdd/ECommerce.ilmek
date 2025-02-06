using System.ComponentModel.DataAnnotations;

namespace ECommerce.MVC.Models.AuthModels
{
    public class SellerLoginModel
    {
        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
