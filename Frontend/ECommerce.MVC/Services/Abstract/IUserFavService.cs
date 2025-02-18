using ECommerce.MVC.Models.UserFavModels;
using ECommerce.MVC.Views.Shared.ResponseViewModels;
using ECommerce.Shared.DTOs.ResponseDTOs;
using ECommerce.Shared.DTOs.UserFavDTOs;

namespace ECommerce.MVC.Services.Abstract
{
    public interface IUserFavService
    {
        Task<ResponseViewModel<UserFavCreateModel>> AddToFavoritesAsync(UserFavCreateModel userFavCreateModel);
        Task<ResponseViewModel<IEnumerable<UserFavModel>>> GetUserFavoritesAsync(int? take = null);

        Task<ResponseViewModel<int>> GetFavoriteCountAsync(string applicationUserId);

        Task<ResponseViewModel<NoContentViewModel>> RemoveFromFavoritesAsync(int favId);
    }
}
