using ECommerce.Business.Abstract;
using ECommerce.Shared.DTOs.AuthDTOs;
using ECommerce.Shared.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : CustomControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("LoginUser")]
        public async Task<IActionResult> LoginUser([FromBody] UserLoginDTO userLoginDTO)
        {
            var response = await _authService.LoginUserAsync(userLoginDTO);
            return CreateResponse(response);
        }

        [HttpPost("RegisterUser")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegisterDTO userRegisterDTO)
        {
            var response = await _authService.RegisterUserAsync(userRegisterDTO);
            return CreateResponse(response);
        }

        [HttpPost("LoginSeller")]
        public async Task<IActionResult> LoginSeller([FromBody] SellerLoginDTO sellerLoginDTO)
        {
            var response = await _authService.LoginSellerAsync(sellerLoginDTO);
            return CreateResponse(response);
        }

        [HttpPost("RegisterSeller")]
        public async Task<IActionResult> RegisterSeller([FromBody] SellerRegisterDTO sellerRegisterDTO)
        {
            var response = await _authService.RegisterSellerAsync(sellerRegisterDTO);
            return CreateResponse(response);
        }

        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDTO forgotPasswordDTO)
        {
            var response = await _authService.ForgotPasswordAsync(forgotPasswordDTO);
            return CreateResponse(response);
        }

        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDTO changePasswordDTO)
        {
            var response = await _authService.ChangePasswordAsync(changePasswordDTO);
            return CreateResponse(response);
        }

        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDTO resetPasswordDTO)
        {
            var response = await _authService.ResetPasswordAsync(resetPasswordDTO);
            return CreateResponse(response);
        }

    }
}
