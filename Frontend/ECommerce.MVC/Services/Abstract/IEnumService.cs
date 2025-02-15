using ECommerce.MVC.Models.EnumResponseModels;
using ECommerce.MVC.Views.Shared.ResponseViewModels;

namespace ECommerce.MVC.Services.Abstract
{
    public interface IEnumService
    {
        Task<ResponseViewModel<IEnumerable<EnumResponseModel>>> GetAvailableColorsAsync();
        Task<ResponseViewModel<IEnumerable<EnumResponseModel>>> GetAvailableSizesAsync();
    }
}
