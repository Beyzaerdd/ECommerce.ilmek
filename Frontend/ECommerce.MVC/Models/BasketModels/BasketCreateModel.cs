using System.ComponentModel.DataAnnotations;

namespace ECommerce.MVC.Models.BasketModels
{
    public class BasketCreateModel
    {
        [Required]
        public string ApplicationUserId { get; set; }
    }
}
