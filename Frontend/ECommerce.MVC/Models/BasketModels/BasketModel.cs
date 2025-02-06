using System.ComponentModel.DataAnnotations;

namespace ECommerce.MVC.Models.BasketModels
{
    public class BasketModel
    {
        public int Id { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }

        public ApplicationUserModel ApplicationUser { get; set; }

        public IEnumerable<BasketItemModel> BasketItems { get; set; } = new List<BasketItemModel>();

        [StringLength(20, ErrorMessage = "Kupon kodu en fazla 20 karakter olabilir.")]
        public string? CouponCode { get; set; }
    }
}
