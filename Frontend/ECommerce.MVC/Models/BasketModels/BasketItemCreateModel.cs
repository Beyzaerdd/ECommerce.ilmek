using System.ComponentModel.DataAnnotations;

namespace ECommerce.MVC.Models.BasketModels
{
    public class BasketItemCreateModel
    {
        [Required]
        public int ProductId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Miktar en az 1 olmalıdır.")]
        public int Quantity { get; set; }
    }
}
