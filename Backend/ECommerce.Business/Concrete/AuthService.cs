using ECommerce.Business.Abstract;
using ECommerce.Shared.DTOs.AuthDTOs;
using ECommerce.Shared.DTOs.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Concrete
{
    public class AuthService : IAuthService
    {
        public Task<ResponseDTO<NoContent>> ChangePasswordAsync(ChangePasswordDTO changePasswordDTO)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO<NoContent>> ForgotPasswordAsync(ForgotPasswordDTO forgotPasswordDTO)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO<TokenDTO>> LoginSellerAsync(SellerLoginDTO sellerLoginDTO)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO<TokenDTO>> LoginUserAsync(UserLoginDTO userLoginDTO)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO<NoContent>> RegisterSellerAsync(SellerRegisterDTO sellerRegisterDTO)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO<NoContent>> RegisterUserAsync(UserRegisterDTO userRegisterDTO)
        {
            throw new NotImplementedException();
        }
    }
}
