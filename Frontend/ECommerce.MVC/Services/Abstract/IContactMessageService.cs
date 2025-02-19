using ECommerce.MVC.Models.ContactMessageModels;
using ECommerce.MVC.Views.Shared.ResponseViewModels;
using ECommerce.Shared.DTOs.ContactMessageDTOs;
using ECommerce.Shared.DTOs.ResponseDTOs;

namespace ECommerce.MVC.Services.Abstract
{
    public interface IContactMessageService
    {
        Task<ResponseViewModel<NoContentViewModel>> AddContactMessageAsync(ContactMessageCreateModel contactMessageCreateModel);
    }
}
