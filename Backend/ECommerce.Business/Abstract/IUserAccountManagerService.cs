using ECommerce.Entity.Concrete;
using ECommerce.Shared.DTOs.ResponseDTOs;
using ECommerce.Shared.DTOs.UserDTO;
using ECommerce.Shared.DTOs.UsersDTO;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Abstract
{
    public interface IUserAccountManagerService
    {
        Task<ResponseDTO<IEnumerable<ApplicationUserDTO>>> GetPendingSellersAsync();
        Task<ResponseDTO<ApplicationUserDTO>> ApproveSellerAsync(string sellerId); 
        Task <ResponseDTO<IEnumerable<ApplicationUserDTO>>> GetAllSellersAsync();
        Task<ResponseDTO<IEnumerable<ApplicationUserDTO>>> GetAllUsersAsync();
        Task<ResponseDTO<ApplicationUserDTO>> GetUserByIdAsync(string userId);
        Task<ResponseDTO<ApplicationUserDTO>> GetSellerByIdAsync(string sellerId);

        Task<ResponseDTO<ApplicationUserDTO>> GetUserAccountDetails();
        Task<ResponseDTO<Seller>> GetSellerAccountDetails();

        Task<ResponseDTO<UpdateUserProfileDTO>> UpdateUserProfile(UpdateUserProfileDTO model);
        Task<ResponseDTO<UpdateSellerProfileDTO>> UpdateSellerProfile(UpdateSellerProfileDTO model);


    }
}
