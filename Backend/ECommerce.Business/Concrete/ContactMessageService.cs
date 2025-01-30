using AutoMapper;
using ECommerce.Business.Abstract;
using ECommerce.Data.Abstract;
using ECommerce.Entity.Concrete;
using ECommerce.Shared.DTOs.ContactMessageDTOs;
using ECommerce.Shared.DTOs.ProductDTOs;
using ECommerce.Shared.DTOs.ResponseDTOs;
using ECommerce.Shared.Extensions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Concrete
{
    public class ContactMessageService : IContactMessageService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IHttpContextAccessor httpContextAccessor;

        public ContactMessageService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<ResponseDTO<NoContent>> AddContactMessageAsync(ContactMessageCreateDTO contactMessageCreateDTO)
        {
            if(contactMessageCreateDTO == null)
            {
                return ResponseDTO<NoContent>.Fail(new List<ErrorDetail>
                {
                    new ErrorDetail { Message = "Contact message is null.", Code = "CONTACT_MESSAGE_IS_NULL", Target = "ContactMessage" }
                }, HttpStatusCode.BadRequest);
            }

            var message = mapper.Map<ContactMessageCreateDTO, ContactMessage>(contactMessageCreateDTO);
            message.ApplicationUserId = httpContextAccessor.GetUserId();

            var contactMessage = await unitOfWork.GetRepository<ContactMessage>().AddAsync(message);

            await unitOfWork.SaveChangesAsync();
            return ResponseDTO<NoContent>.Success(HttpStatusCode.Created);


        }

        public async Task<ResponseDTO<NoContent>> DeleteContactMessageAsync(int contactMessageId)
        {
            if(contactMessageId <= 0 )
            {
                return ResponseDTO<NoContent>.Fail(new List<ErrorDetail>
                {
                    new ErrorDetail { Message = "Contact message id is null.", Code = "CONTACT_MESSAGE_ID_IS_NULL", Target = "ContactMessage" }
                }, HttpStatusCode.BadRequest);
            }

            var contactMessage = await unitOfWork.GetRepository<ContactMessage>().GetByIdAsync(contactMessageId);
            if (contactMessage == null)
            {
                return ResponseDTO<NoContent>.Fail(new List<ErrorDetail>
                {
                    new ErrorDetail { Message = "Contact message not found.", Code = "CONTACT_MESSAGE_NOT_FOUND", Target = "ContactMessage" }
                }, HttpStatusCode.NotFound);
            }

            unitOfWork.GetRepository<ContactMessage>().SoftDeleteAsync(contactMessage);
            await unitOfWork.SaveChangesAsync();
            return ResponseDTO<NoContent>.Success(HttpStatusCode.NoContent);

        }

     

        public async Task<ResponseDTO<IEnumerable<ContactMessageDTO>>> GetContactMessageByUserIdAsync(string applicationUserId)
        {
           if(applicationUserId == null )
            {
                return ResponseDTO<IEnumerable<ContactMessageDTO>>.Fail(new List<ErrorDetail>
                {
                    new ErrorDetail { Message = "Application user id is null.", Code = "APPLICATION_USER_ID_IS_NULL", Target = "ApplicationUser" }
                }, HttpStatusCode.BadRequest);

            }

            var contactMessages = await unitOfWork.GetRepository<ContactMessage>().GetAllAsync(x => x.ApplicationUserId == applicationUserId);
            if (contactMessages == null) {
                return ResponseDTO<IEnumerable<ContactMessageDTO>>.Fail(new List<ErrorDetail>
                {
                    new ErrorDetail { Message = "Contact messages not found.", Code = "CONTACT_MESSAGES_NOT_FOUND", Target = "ContactMessage" }
                }, HttpStatusCode.NotFound);
            }

            var contactMessagesDTO = mapper.Map<IEnumerable<ContactMessageDTO>>(contactMessages);
            return ResponseDTO<IEnumerable<ContactMessageDTO>>.Success(contactMessagesDTO, HttpStatusCode.OK);
        }

        public async  Task<ResponseDTO<IEnumerable<ContactMessageDTO>>> GetContactMessagesAsync()
        {
            var contactMessages = await unitOfWork.GetRepository<ContactMessage>().GetAllAsync();
            var contactMessagesDTO = mapper.Map<IEnumerable<ContactMessageDTO>>(contactMessages);
            if (contactMessagesDTO == null) {
                return ResponseDTO<IEnumerable<ContactMessageDTO>>.Fail(new List<ErrorDetail>
                {
                    new ErrorDetail { Message = "Contact messages not found.", Code = "CONTACT_MESSAGES_NOT_FOUND", Target = "ContactMessage" }
                }, HttpStatusCode.NotFound);
            }
            return ResponseDTO<IEnumerable<ContactMessageDTO>>.Success(contactMessagesDTO, HttpStatusCode.OK);

        }
    }
}
