using ECommerce.MVC.Models.AuthModels;
using ECommerce.MVC.Views.Shared.ResponseViewModels;

namespace ECommerce.MVC.Services.Abstract
{
    public interface IAuthService
    {
        Task<ResponseViewModel<TokenModel>> LoginUserAsync(LoginUserModel userLoginModel);
        Task<ResponseViewModel<NoContentViewModel>> RegisterUserAsync(RegisterUserModel userRegisterModel);

        Task<ResponseViewModel<TokenModel>> LoginSellerAsync(LoginSellerModel sellerLoginModel);
        Task<ResponseViewModel<string>> RegisterSellerAsync(RegisterSellerModel sellerRegisterModel);

        Task<ResponseViewModel<NoContentViewModel>> ForgotPasswordAsync(ForgotPasswordModel forgotPasswordModel);
        Task<ResponseViewModel<NoContentViewModel>> ChangePasswordAsync(ChangePasswordModel changePasswordModel);
        Task<ResponseViewModel<NoContentViewModel>> ResetPasswordAsync(ResetPasswordModel resetPasswordModel);

    }
}
