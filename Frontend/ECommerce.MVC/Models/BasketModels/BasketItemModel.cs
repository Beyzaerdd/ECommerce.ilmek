using System.ComponentModel.DataAnnotations;

namespace ECommerce.MVC.Models.BasketModels
{
    public class BasketItemModel
    {
        public int Id { get; set; }

        [Required]
        public int BasketId { get; set; }

        [Required]
        public int ProductId { get; set; }

        public ProductModel Product { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Miktar en az 1 olmalıdır.")]
        public int Quantity { get; set; }


        public decimal OriginalPrice { get; set; }

        public decimal DiscountedPrice { get; set; }
    }
}
