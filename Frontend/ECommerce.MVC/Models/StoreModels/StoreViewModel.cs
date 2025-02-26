using ECommerce.MVC.Models.ProductModels;
using ECommerce.MVC.Models.UserModels;

namespace ECommerce.MVC.Models.StoreModels
{
    public class StoreViewModel
    {
        public string StoreName { get; set; }
        public string ApplicationUserId { get; set; }
        public List<ProductModel> Products { get; set; } = new List<ProductModel>();

        public int PageNumber { get; set; }
        public int TotalPages { get; set; }

   
        public ApplicationUserModel Seller { get; set; }
    }

}
