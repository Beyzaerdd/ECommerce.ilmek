using System.ComponentModel.DataAnnotations;

namespace ECommerce.MVC.Models.BasketModels
{
    public class BasketItemChangeQuantityModel
    {
        [Required]
        public int BasketItemId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Miktar en az 1 olmalıdır.")]
        public int Quantity { get; set; }
    }
}
