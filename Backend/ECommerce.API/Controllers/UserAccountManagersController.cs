using ECommerce.Business.Abstract;
using ECommerce.Shared.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountManagersController : CustomControllerBase
    {
        private readonly IUserAccountManagerService _userManagerService;

        public UserAccountManagersController(IUserAccountManagerService userManagerService)
        {
            _userManagerService = userManagerService;
        }

        [Authorize(Policy = "Admin")]
        [HttpGet("getPendingSellers")]
        public async Task<IActionResult> GetPendingSellers()
        {
            var response = await _userManagerService.GetPendingSellersAsync();
            return CreateResponse(response);
        }

        [Authorize(Policy = "Admin")]
        [HttpPost("approveSeller")]
        public async Task<IActionResult> ApproveSeller([FromQuery] string sellerId)
        {
            var response = await _userManagerService.ApproveSellerAsync(sellerId);
            return CreateResponse(response);
        }

        [Authorize(Policy = "Admin")]
        [HttpGet("getAllSellers")]
        public async Task<IActionResult> GetAllSellers()
        {
            var response = await _userManagerService.GetAllSellersAsync();
            return CreateResponse(response);
        }

        [Authorize(Policy = "Admin")]
        [HttpGet("getAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var response = await _userManagerService.GetAllUsersAsync();
            return CreateResponse(response);
        }
        [Authorize(Policy = "Admin")]
        [HttpGet("getUserById")]
        public async Task<IActionResult> GetUserById([FromQuery] string userId)
        {
            var response = await _userManagerService.GetUserByIdAsync(userId);
            return CreateResponse(response);
        }

        [Authorize(Policy = "User")]
        [HttpGet("getUserAccountDetails")]
        public async Task<IActionResult> GetUserAccountDetails()
        {
            var response = await _userManagerService.GetUserAccountDetails();
            return CreateResponse(response);
        }
        [Authorize(Policy = "User")]
        [HttpGet("getSellerAccountDetails")]

        public async Task<IActionResult> GetSellerAccountDetails()
        {
            var response = await _userManagerService.GetSellerAccountDetails();
            return CreateResponse(response);
        }





    }
}
