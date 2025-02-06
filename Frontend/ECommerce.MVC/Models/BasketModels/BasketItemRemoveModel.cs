using System.ComponentModel.DataAnnotations;

namespace ECommerce.MVC.Models.BasketModels
{
    public class BasketItemRemoveModel
    {
        [Required]
        public int BasketId { get; set; }

        [Required]
        public int ProductId { get; set; }
    }
}
