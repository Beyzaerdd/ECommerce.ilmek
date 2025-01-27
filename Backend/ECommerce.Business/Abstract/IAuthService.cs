﻿using ECommerce.Shared.DTOs.AuthDTOs;
using ECommerce.Shared.DTOs.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Abstract
{
    public interface IAuthService
    {
        Task<ResponseDTO<TokenDTO>> LoginUserAsync(UserLoginDTO userLoginDTO);
        Task<ResponseDTO<NoContent>> RegisterUserAsync(UserRegisterDTO userRegisterDTO);
        Task<ResponseDTO<TokenDTO>> LoginSellerAsync(SellerLoginDTO sellerLoginDTO);
        Task<ResponseDTO<NoContent>> RegisterSellerAsync(SellerRegisterDTO sellerRegisterDTO);

        Task<ResponseDTO<NoContent>> ForgotPasswordAsync(ForgotPasswordDTO forgotPasswordDTO);
        Task<ResponseDTO<NoContent>> ChangePasswordAsync(ChangePasswordDTO changePasswordDTO);

    }
}
