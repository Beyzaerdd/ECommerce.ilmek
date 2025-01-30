using ECommerce.Shared.DTOs.ContactMessageDTOs;
using ECommerce.Shared.DTOs.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Abstract
{
    public interface IContactMessageService
    {
        Task<ResponseDTO<NoContent>> AddContactMessageAsync(ContactMessageCreateDTO contactMessageCreateDTO);
        Task<ResponseDTO<IEnumerable<ContactMessageDTO>>> GetContactMessagesAsync();
        Task<ResponseDTO<IEnumerable<ContactMessageDTO>>> GetContactMessageByUserIdAsync(string applicationUserId);
        Task<ResponseDTO<NoContent>> DeleteContactMessageAsync(int contactMessageId);
    }
}
