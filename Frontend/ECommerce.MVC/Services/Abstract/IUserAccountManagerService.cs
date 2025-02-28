

using ECommerce.MVC.Models.UserModels;
using ECommerce.MVC.Views.Shared.ResponseViewModels;
using ECommerce.Shared.DTOs.ResponseDTOs;
using ECommerce.Shared.DTOs.UsersDTO;

namespace ECommerce.MVC.Services.Abstract
{
    public interface IUserAccountManagerService
    {
        Task<ResponseViewModel<ApplicationUserModel>> GetUserAccountDetails();
        Task<ResponseViewModel<ApplicationUserModel>> GetSellerAccountDetails();

        Task<ResponseViewModel<ApplicationUserModel>> GetUserByIdAsync(string userId);
        Task<ResponseViewModel<ApplicationUserModel>> GetSellerByIdAsync(string sellerId);

        Task<ResponseViewModel<UpdateUserProfileModel>> UpdateUserProfile(UpdateUserProfileModel model);
        Task<ResponseViewModel<ApplicationUserModel>> UpdateSellerProfile(ApplicationUserModel model);
    }
}
