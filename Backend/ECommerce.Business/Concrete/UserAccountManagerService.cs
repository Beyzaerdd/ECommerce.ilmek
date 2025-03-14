using AutoMapper;
using ECommerce.Business.Abstract;
using ECommerce.Data.Abstract;
using ECommerce.Entity.Concrete;
using ECommerce.Shared.DTOs.CategoryDTOs;
using ECommerce.Shared.DTOs.ResponseDTOs;
using ECommerce.Shared.DTOs.UserDTO;
using ECommerce.Shared.DTOs.UsersDTO;
using ECommerce.Shared.Extensions;
using Fluid;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata;
using Newtonsoft.Json;
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
        private readonly IEmailService emailService;


        public UserAccountManagerService(IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork, IMapper mapper, UserManager<ApplicationUser> userManager, IEmailService emailService)
        {
            this.httpContextAccessor = httpContextAccessor;

            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            _userManager = userManager;
            this.emailService = emailService;
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
            await SendSellerApprovalMail(seller);

            var sellerDTO = mapper.Map<ApplicationUserDTO>(seller);
            return ResponseDTO<ApplicationUserDTO>.Success(sellerDTO, HttpStatusCode.OK);
        }

        private async Task SendSellerApprovalMail(Seller seller)
        {
            string subject = "Tebrikler! Mağazanız Onaylandı 🎉";

            try
            {
                var basePath = Path.Combine(Directory.GetCurrentDirectory(), "Templates");
                var templatePath = Path.Combine(basePath, "SellerApprovalTemplate.liquid");

                if (!File.Exists(templatePath))
                {
                    throw new FileNotFoundException($"Şablon dosyası bulunamadı: {templatePath}");
                }

                var templateText = await File.ReadAllTextAsync(templatePath);
                var parser = new FluidParser();

                if (!parser.TryParse(templateText, out var template, out var error))
                {
                    throw new InvalidOperationException("Şablon ayrıştırma hatası: " + error);
                }

                var templateContext = new TemplateContext();
                var sellerData = new Dictionary<string, object>
        {
            { "FirstName", seller.FirstName },
            { "LastName", seller.LastName },
            { "Email", seller.Email },
            { "sellerPanelUrl", "https://ilmek.com/seller-panel" }
        };

                templateContext.SetValue("seller", sellerData);
                var body = template.Render(templateContext);

                await emailService.SendEmailAsync(seller.Email, subject, body);
            }
            catch (Exception ex)
            {
                Console.WriteLine("E-posta gönderme hatası: " + ex.Message);
                throw;
            }
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




        public async Task<ResponseDTO<IEnumerable<ApplicationUserDTO>>> GetAllUsersAsync()
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
                IsActive = seller.IsActive,
                Address=seller.Address,
                DateOfBirth = seller.DateOfBirth,
                PhoneNumber = seller.PhoneNumber,
             
                IsApproved = seller.IsApproved,
                IdentityNumber = seller.IdentityNumber,
                FirstName = seller.FirstName,
                LastName = seller.LastName,
                WeeklyOrderLimit = seller.WeeklyOrderLimit,
                UserName=seller.UserName,
               
                 

                







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
                Id=user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Address = user.Address,
                PhoneNumber = user.PhoneNumber,
            };

            return ResponseDTO<ApplicationUserDTO>.Success(userDTO, HttpStatusCode.OK);
        }


        public async Task<ResponseDTO<ApplicationUserDTO>> GetUserByIdAsync(string userId)
        {
            var user = await unitOfWork.GetRepository<ApplicationUser>().GetAsync(u => u.Id == userId);
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

        public async Task<ResponseDTO<ApplicationUserDTO>> GetSellerByIdAsync(string sellerId)
        {
            var seller = await unitOfWork.GetRepository<Seller>().GetAsync(u => u.Id == sellerId);

            if (seller == null)
            {
                return ResponseDTO<ApplicationUserDTO>.Fail(new List<ErrorDetail>
                {
                    new ErrorDetail
                    {
                        Message = "Seller not found.",
                        Code = "UserNotFound",
                        Target = nameof(Seller)
                    }
                }, HttpStatusCode.NotFound);
            }

            var userDTO = new ApplicationUserDTO
            {
                Id = seller.Id,
                StoreName = seller.StoreName
            };
            return ResponseDTO<ApplicationUserDTO>.Success(userDTO, HttpStatusCode.OK);

        }

        public async Task<ResponseDTO<UpdateUserProfileDTO>> UpdateUserProfile(UpdateUserProfileDTO model)
        {
           
            var userId = httpContextAccessor.GetUserId();
            if (string.IsNullOrEmpty(userId))
            {
                return ResponseDTO<UpdateUserProfileDTO>.Fail(new List<ErrorDetail>
        {
            new ErrorDetail
            {
                Message = "User ID not found in context.",
                Code = "UserIdNotFound",
                Target = "User"
            }
        }, HttpStatusCode.Unauthorized);
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return ResponseDTO<UpdateUserProfileDTO>.Fail(new List<ErrorDetail>
        {
            new ErrorDetail
            {
                Message = "User not found.",
                Code = "UserNotFound",
                Target = nameof(user)
            }
        }, HttpStatusCode.NotFound);
            }


            user.FirstName = model.FirstName ?? user.FirstName;
            user.LastName = model.LastName ?? user.LastName;
            user.Address = model.Address ?? user.Address;
            user.PhoneNumber = model.PhoneNumber ?? user.PhoneNumber;



            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                return ResponseDTO<UpdateUserProfileDTO>.Fail(new List<ErrorDetail>
        {
            new ErrorDetail
            {
                Message = "User update failed.",
                Code = "UserUpdateFailed",
                Target = nameof(user)
            }
        }, HttpStatusCode.BadRequest);
            }

            return ResponseDTO<UpdateUserProfileDTO>.Success(model, HttpStatusCode.OK);
        }
        public async Task<ResponseDTO<UpdateSellerProfileDTO>> UpdateSellerProfile(UpdateSellerProfileDTO model)
        {
        
            var userId = httpContextAccessor.GetUserId();
            if (string.IsNullOrEmpty(userId))
            {
                return ResponseDTO<UpdateSellerProfileDTO>.Fail(new List<ErrorDetail>
        {
            new ErrorDetail
            {
                Message = "User ID not found in context.",
                Code = "UserIdNotFound",
                Target = "Seller"
            }
        }, HttpStatusCode.Unauthorized);
            }

            var seller = await unitOfWork.GetRepository<Seller>().GetAsync(s => s.Id == userId);
            if (seller == null)
            {
                return ResponseDTO<UpdateSellerProfileDTO>.Fail(new List<ErrorDetail>
        {
            new ErrorDetail
            {
                Message = "Seller not found.",
                Code = "SellerNotFound",
                Target = nameof(seller)
            }
        }, HttpStatusCode.NotFound);
            }

            seller.StoreName = model.StoreName;
            seller.Email = model.Email;
            seller.PhoneNumber = model.PhoneNumber;
            seller.Address = model.Address;
            seller.WeeklyOrderLimit = model.WeeklyOrderLimit;
            seller.IsActive = model.IsActive;
            seller.FirstName = model.FirstName;
            seller.LastName = model.LastName;


            unitOfWork.GetRepository<Seller>().UpdateAsync(seller);
            await unitOfWork.SaveChangesAsync();

            return ResponseDTO<UpdateSellerProfileDTO>.Success(model, HttpStatusCode.OK);
        }

    }
}