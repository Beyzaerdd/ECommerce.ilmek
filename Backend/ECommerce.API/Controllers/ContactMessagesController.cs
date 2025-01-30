using ECommerce.Business.Abstract;
using ECommerce.Shared.DTOs.ContactMessageDTOs;
using ECommerce.Shared.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactMessagesController : CustomControllerBase
    {
        private readonly IContactMessageService _contactMessageService;

        public ContactMessagesController(IContactMessageService contactMessageService)
        {
            _contactMessageService = contactMessageService;
        }
        [Authorize]
        [HttpPost("send")]
        public async Task<IActionResult> SendContactMessage([FromBody] ContactMessageCreateDTO contactMessageCreateDTO)
        {
            var response = await _contactMessageService.AddContactMessageAsync(contactMessageCreateDTO);
            return CreateResponse(response);
        }

        [Authorize(Policy = "Admin")]
        [HttpGet("getContactMessages")]
        public async Task<IActionResult> GetContactMessages()
        {
            var response = await _contactMessageService.GetContactMessagesAsync();
            return CreateResponse(response);
        }

        [Authorize(Policy = "Admin")]
        [HttpGet("getContactMessagesByUser")]
        public async Task<IActionResult> GetContactMessagesByUser([FromQuery] string applicationUserId)
        {
            var response = await _contactMessageService.GetContactMessageByUserIdAsync(applicationUserId);
            return CreateResponse(response);
        }

        [Authorize(Policy = "Admin")]
        [HttpDelete("deleteContactMessage")]
        public async Task<IActionResult> DeleteContactMessage([FromRoute] int id)
        {
            var response = await _contactMessageService.DeleteContactMessageAsync(id);
            return CreateResponse(response);
        }
    }
}
