using System.ComponentModel.DataAnnotations;

namespace ECommerce.MVC.Models.AuthModels
{
    public class ForgotPasswordModel
    {
        [Required, EmailAddress]
        public string Email { get; set; }
    }
}
