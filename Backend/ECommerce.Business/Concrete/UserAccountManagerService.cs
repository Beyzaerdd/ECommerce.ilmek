using AutoMapper;
using ECommerce.Business.Abstract;
using ECommerce.Data.Abstract;
using ECommerce.Entity.Concrete;
using ECommerce.Shared.DTOs.CategoryDTOs;
using ECommerce.Shared.DTOs.ResponseDTOs;
using ECommerce.Shared.DTOs.UsersDTO;
using ECommerce.Shared.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Concrete
{
    public class UserAccountManagerService : IUserAccountManagerService
    {
   
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationUser> _userManager;


        public UserAccountManagerService(IHttpContextAccessor httpContextAccessor,  IUnitOfWork unitOfWork, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            this.httpContextAccessor = httpContextAccessor;
         
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            _userManager = userManager;
        }

        public async Task<ResponseDTO<ApplicationUserDTO>> ApproveSellerAsync(string sellerId)
        {
            
            var seller = await unitOfWork.GetRepository<Seller>().GetAsync(s => s.Id == sellerId);

            if (seller == null)
            {
                return ResponseDTO<ApplicationUserDTO>.Fail(new List<ErrorDetail>
        {
            new ErrorDetail
            {
                Message = "Seller not found.",
                Code = "SellerNotFound",
                Target = nameof(sellerId)
            }
        }, HttpStatusCode.NotFound);
            }

          
            if (seller.IsApproved)
            {
                return ResponseDTO<ApplicationUserDTO>.Fail(new List<ErrorDetail>
        {
            new ErrorDetail
            {
                Message = "Seller is already approved.",
                Code = "AlreadyApproved",
                Target = nameof(sellerId)
            }
        }, HttpStatusCode.BadRequest);
            }

            seller.IsApproved = true;
            seller.IsActive = true;
      

      
            unitOfWork.GetRepository<Seller>().UpdateAsync(seller);
            await unitOfWork.SaveChangesAsync();

            var sellerDTO = mapper.Map<ApplicationUserDTO>(seller);
            return ResponseDTO<ApplicationUserDTO>.Success(sellerDTO, HttpStatusCode.OK);
        }


        public async Task<ResponseDTO<IEnumerable<ApplicationUserDTO>>> GetAllSellersAsync()
        {
            var allSellers = await unitOfWork.GetRepository<Seller>().GetAllAsync();
            if (allSellers == null || !allSellers.Any())
            {
                return ResponseDTO<IEnumerable<ApplicationUserDTO>>.Fail(new List<ErrorDetail>
{
                  new ErrorDetail
                  {
                            Message = "No Seller is found.",
                               Code = "SellerNotFound",
                              Target = nameof(allSellers)
                     }
                    }, HttpStatusCode.NotFound);
            }
                var sellerDTOs = mapper.Map<IEnumerable<ApplicationUserDTO>>(allSellers);
                return ResponseDTO<IEnumerable<ApplicationUserDTO>>.Success(sellerDTOs, HttpStatusCode.OK);

            }


        

        public async  Task<ResponseDTO<IEnumerable<ApplicationUserDTO>>> GetAllUsersAsync()
        {
           var allUsers = await unitOfWork.GetRepository<ApplicationUser>().GetAllAsync();
            if (allUsers == null || !allUsers.Any())
            {
                return ResponseDTO<IEnumerable<ApplicationUserDTO>>.Fail(new List<ErrorDetail>
                    {
                  new ErrorDetail
                  {
                            Message = "No User is found.",
                               Code = "UserNotFound",
                              Target = nameof(allUsers)
                     }
                    }, HttpStatusCode.NotFound);
            }
                var userDTOs = mapper.Map<IEnumerable<ApplicationUserDTO>>(allUsers);
                return ResponseDTO<IEnumerable<ApplicationUserDTO>>.Success(userDTOs, HttpStatusCode.OK);
            }

        public async Task<ResponseDTO<IEnumerable<ApplicationUserDTO>>> GetPendingSellersAsync()
        {
           
            var pendingSellers = await unitOfWork.GetRepository<Seller>()
                .GetAllAsync(s => !s.IsApproved);

            if (pendingSellers == null || !pendingSellers.Any())
            {
                return ResponseDTO<IEnumerable<ApplicationUserDTO>>.Fail(new List<ErrorDetail>
        {
            new ErrorDetail
            {
                Message = "No pending sellers found.",
                Code = "PendingSellersNotFound",
                Target = "PendingSellers"
            }
        }, HttpStatusCode.NotFound);
            }

      
            var pendingSellersDTO = mapper.Map<IEnumerable<ApplicationUserDTO>>(pendingSellers);
            return ResponseDTO<IEnumerable<ApplicationUserDTO>>.Success(pendingSellersDTO, HttpStatusCode.OK);
        }

        public async Task<ResponseDTO<Seller>> GetSellerAccountDetails()
        {
           
            var userId = httpContextAccessor.GetUserId();
            if (string.IsNullOrEmpty(userId))
            {
                return ResponseDTO<Seller>.Fail(new List<ErrorDetail>
        {
            new ErrorDetail
            {
                Message = "User ID not found in context.",
                Code = "UserIdNotFound",
                Target = nameof(userId)
            }
        }, HttpStatusCode.Unauthorized);
            }

       
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return ResponseDTO<Seller>.Fail(new List<ErrorDetail>
        {
            new ErrorDetail
            {
                Message = "User not found.",
                Code = "UserNotFound",
                Target = nameof(user)
            }
        }, HttpStatusCode.NotFound);
            }

           
            if (user is not Seller seller)
            {
                return ResponseDTO<Seller>.Fail(new List<ErrorDetail>
        {
            new ErrorDetail
            {
                Message = "User is not a seller.",
                Code = "NotASeller",
                Target = nameof(user)
            }
        }, HttpStatusCode.BadRequest);
            }

        
            var sellerDTO = new Seller
            {
              
                StoreName = seller.StoreName,
                Email = seller.Email,
             
                
               
            };

      
            return ResponseDTO<Seller>.Success(sellerDTO, HttpStatusCode.OK);
        }


        public async Task<ResponseDTO<ApplicationUserDTO>> GetUserAccountDetails()
        {
    
            var userId = httpContextAccessor.GetUserId();
            if (string.IsNullOrEmpty(userId))
            {
                return ResponseDTO<ApplicationUserDTO>.Fail(new List<ErrorDetail>
        {
            new ErrorDetail
            {
                Message = "User ID not found in context.",
                Code = "UserIdNotFound",
                Target = nameof(userId)
            }
        }, HttpStatusCode.Unauthorized);
            }

         
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return ResponseDTO<ApplicationUserDTO>.Fail(new List<ErrorDetail>
        {
            new ErrorDetail
            {
                Message = "User not found.",
                Code = "UserNotFound",
                Target = nameof(user)
            }
        }, HttpStatusCode.NotFound);
            }

      
            var userDTO = new ApplicationUserDTO
            {
             
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Address = user.Address,
                City = user.City,
                DateOfBirth = user.DateOfBirth,
                PhoneNumber = user.PhoneNumber,
            };

            return ResponseDTO<ApplicationUserDTO>.Success(userDTO, HttpStatusCode.OK);
        }


        public async  Task<ResponseDTO<ApplicationUserDTO>> GetUserByIdAsync(string userId)
        {
            var user =await  unitOfWork.GetRepository<ApplicationUser>().GetAsync(u => u.Id == userId);
            if (user == null)
            {
                return ResponseDTO<ApplicationUserDTO>.Fail(new List<ErrorDetail>
                {
                    new ErrorDetail
                    {
                        Message = "User not found.",
                        Code = "UserNotFound",
                        Target = nameof(user)
                    }
                }, HttpStatusCode.NotFound);
            }

            var userDTO = mapper.Map<ApplicationUserDTO>(user);
            return ResponseDTO<ApplicationUserDTO>.Success(userDTO, HttpStatusCode.OK);
        }
    }
}
