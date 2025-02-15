

using ECommerce.MVC.Models.UserModels;
using ECommerce.MVC.Views.Shared.ResponseViewModels;

namespace ECommerce.MVC.Services.Abstract
{
    public interface IUserAccountManagerService
    {
        Task<ResponseViewModel<ApplicationUserModel>> GetUserAccountDetails();
        Task<ResponseViewModel<ApplicationUserModel>> GetSellerAccountDetails();

        Task<ResponseViewModel<ApplicationUserModel>> GetUserByIdAsync(string userId);
        Task<ResponseViewModel<ApplicationUserModel>> GetSellerByIdAsync(string sellerId);
    }
}
