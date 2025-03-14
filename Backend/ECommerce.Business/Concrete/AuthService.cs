﻿using ECommerce.Business.Abstract;
using ECommerce.Business.Configuration;
using ECommerce.Entity.Concrete;
using ECommerce.Shared.DTOs.AuthDTOs;
using ECommerce.Shared.DTOs.BasketDTOs;
using ECommerce.Shared.DTOs.InvoiceDTOs;
using ECommerce.Shared.DTOs.ResponseDTOs;
using ECommerce.Shared.DTOs.UsersDTO;
using ECommerce.Shared.Extensions;
using Fluid;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Concrete
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly JwtConfig _jwtConfig;
        private readonly IEmailService _emailService;
        private readonly IBasketService _basketService;
        private readonly IHttpContextAccessor httpContextAccessor;


        public AuthService(IBasketService basketService, IEmailService emailService, IOptions<JwtConfig> jwtConfig, IConfiguration configuration, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _basketService = basketService;
            _emailService = emailService;
            _jwtConfig = jwtConfig.Value;
            _configuration = configuration;
            _userManager = userManager;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<ResponseDTO<NoContent>> ChangePasswordAsync(ChangePasswordDTO changePasswordDTO)
        {
            var user = await _userManager.FindByEmailAsync(changePasswordDTO.Email);
            if (user == null)
            {
                return ResponseDTO<NoContent>.Fail("Kullanıcı bulunamadı", HttpStatusCode.NotFound);
            }

            var isValidPassword = await _userManager.CheckPasswordAsync(user, changePasswordDTO.CurrentPassword);
            if (!isValidPassword)
            {
                return ResponseDTO<NoContent>.Fail("Geçersiz şifre", HttpStatusCode.BadRequest);
            }
            if (changePasswordDTO.NewPassword == changePasswordDTO.CurrentPassword)
            {
                return ResponseDTO<NoContent>.Fail("Yakın zamanda kullandınız başka bir şifre giriniz", HttpStatusCode.BadRequest);

            }


            var result = await _userManager.ChangePasswordAsync(user, changePasswordDTO.CurrentPassword, changePasswordDTO.NewPassword);
            if (!result.Succeeded)
            {
                return ResponseDTO<NoContent>.Fail(result.Errors.Select(e => new ErrorDetail
                {
                    Message = e.Description,
                    Code = "ChangePasswordFailed",
                    Target = nameof(changePasswordDTO)
                }).ToList(), HttpStatusCode.BadRequest);
            }

            return ResponseDTO<NoContent>.Success(HttpStatusCode.OK);
        }

        public async Task<ResponseDTO<NoContent>> ForgotPasswordAsync(ForgotPasswordDTO forgotPasswordDTO)
        {
            var user = await _userManager.FindByEmailAsync(forgotPasswordDTO.Email);
            if (user == null)
            {
                return ResponseDTO<NoContent>.Fail(new List<ErrorDetail>
        {
            new ErrorDetail
            {
                Message = "Email or Password cannot be empty.",
                Code = "InvalidInput",
                Target = "Email/Password"
            }
        }, HttpStatusCode.BadRequest);
            }

           
            await SendResetPasswordAsync(user);

            return ResponseDTO<NoContent>.Success(HttpStatusCode.OK);
        }

        private async Task SendResetPasswordAsync(ApplicationUser user)
        {
            string subject = "Şifre Sıfırlama Talebi";

            try
            {
                // Load the template for the reset password email
                var templatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates", "ForgotPasswordTemplate.liquid");

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

                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var encodedToken = WebUtility.UrlEncode(token);
                var resetLink = $"http://localhost:7269/Auth/ResetPassword?token={encodedToken}&email={user.Email}";



                var templateContext = new TemplateContext();
                var userData = new Dictionary<string, object>
        {
            { "FirstName", user.FirstName },
            { "Email", user.Email },
            { "ResetLink", resetLink }
        };

                templateContext.SetValue("user", userData);

                // Render the email body with the template
                var body = template.Render(templateContext);

                // Send the email to the user
                await _emailService.SendEmailAsync(user.Email, subject, body);
            }
            catch (Exception ex)
            {
                Console.WriteLine("E-posta gönderme hatası: " + ex.Message);
                throw;
            }
        }
        public async Task<ResponseDTO<NoContent>> ResetPasswordAsync(ResetPasswordDTO resetPasswordDTO)
        {
            var user = await _userManager.FindByEmailAsync(resetPasswordDTO.Email);
            if (user == null)
            {
                return ResponseDTO<NoContent>.Fail("Kullanıcı bulunamadı", HttpStatusCode.NotFound);
            }

            var result = await _userManager.ResetPasswordAsync(user, resetPasswordDTO.Token, resetPasswordDTO.NewPassword);
            if (!result.Succeeded)
            {
                return ResponseDTO<NoContent>.Fail(result.Errors.Select(e => new ErrorDetail
                {
                    Message = e.Description,
                    Code = "ResetPasswordFailed",
                    Target = nameof(resetPasswordDTO)
                }).ToList(), HttpStatusCode.BadRequest);
            }

            return ResponseDTO<NoContent>.Success(HttpStatusCode.OK);
        }



        public async Task<ResponseDTO<TokenDTO>> LoginSellerAsync(SellerLoginDTO sellerLoginDTO)
        {
            if (string.IsNullOrEmpty(sellerLoginDTO.Email) || string.IsNullOrEmpty(sellerLoginDTO.Password))
            {
                return ResponseDTO<TokenDTO>.Fail(new List<ErrorDetail>
                {
                    new ErrorDetail
                    {
                        Message = "Email or Password cannot be empty.",
                        Code = "InvalidInput",
                        Target = "Email/Password"
                    }
                }, HttpStatusCode.BadRequest);
            }

            var user = await _userManager.FindByEmailAsync(sellerLoginDTO.Email);
            if (user == null)
            {
                return ResponseDTO<TokenDTO>.Fail(new List<ErrorDetail>
                {
                    new ErrorDetail
                    {
                        Message = $"User not found with email: {sellerLoginDTO.Email}",
                        Code = "UserNotFound",
                        Target = nameof(sellerLoginDTO.Email)
                    }
                }, HttpStatusCode.NotFound);
            }
            if (user is Seller sellerUser && !sellerUser.IsApproved)
            {
                return ResponseDTO<TokenDTO>.Fail(new List<ErrorDetail>
        {
            new ErrorDetail
            {
                Message = "Your account is awaiting admin approval.",
                Code = "AccountNotApproved",
                Target = nameof(sellerLoginDTO.Email)
            }
        }, HttpStatusCode.Forbidden);
            }
            if (!user.EmailConfirmed)
            {
                return ResponseDTO<TokenDTO>.Fail(new List<ErrorDetail>
                {
                    new ErrorDetail
                    {
                        Message = "Email is not confirmed. Please verify your email.",
                        Code = "EmailNotConfirmed",
                        Target = nameof(sellerLoginDTO.Email)
                    }
                }, HttpStatusCode.BadRequest);
            }
            if (await _userManager.IsLockedOutAsync(user))
            {
                return ResponseDTO<TokenDTO>.Fail(new List<ErrorDetail>
                {
                    new ErrorDetail
                    {
                        Message = "Your account is locked due to multiple failed login attempts.",
                        Code = "AccountLocked",
                        Target = nameof(user.Email)
                    }
                }, HttpStatusCode.Forbidden);
            }
            var isValidPassword = await _userManager.CheckPasswordAsync(user, sellerLoginDTO.Password);
            if (!isValidPassword)
            {
                await _userManager.AccessFailedAsync(user);
                return ResponseDTO<TokenDTO>.Fail(new List<ErrorDetail>
                {
                    new ErrorDetail
                    {
                        Message = "Incorrect password.",
                        Code = "InvalidPassword",
                        Target = nameof(sellerLoginDTO.Password)
                    }
                }, HttpStatusCode.BadRequest);
            }
            await _userManager.ResetAccessFailedCountAsync(user);
            var tokenDTO = await GenerateJwtToken(user);
            return ResponseDTO<TokenDTO>.Success(tokenDTO, HttpStatusCode.OK);
        }

        public async Task<ResponseDTO<TokenDTO>> LoginUserAsync(UserLoginDTO userLoginDTO)
        {

            if (string.IsNullOrWhiteSpace(userLoginDTO.Email) || string.IsNullOrWhiteSpace(userLoginDTO.Password))
            {
                return ResponseDTO<TokenDTO>.Fail(new List<ErrorDetail>
        {
            new ErrorDetail
            {
                Message = "Email or Password cannot be empty.",
                Code = "InvalidInput",
                Target = "Email/Password"
            }
        }, HttpStatusCode.BadRequest);
            }

            var user = await _userManager.FindByEmailAsync(userLoginDTO.Email);
            if (user == null)
            {
                return ResponseDTO<TokenDTO>.Fail(new List<ErrorDetail>
        {
            new ErrorDetail
            {
                Message = $"User not found with email: {userLoginDTO.Email}",
                Code = "UserNotFound",
                Target = nameof(userLoginDTO.Email)
            }
        }, HttpStatusCode.NotFound);
            }

          

            if (await _userManager.IsLockedOutAsync(user))
            {
                return ResponseDTO<TokenDTO>.Fail(new List<ErrorDetail>
        {
            new ErrorDetail
            {
                Message = "Your account is locked due to multiple failed login attempts.",
                Code = "AccountLocked",
                Target = nameof(user.Email)
            }
        }, HttpStatusCode.Forbidden);
            }

            var isValidPassword = await _userManager.CheckPasswordAsync(user, userLoginDTO.Password);
            if (!isValidPassword)
            {
                // Failed login attempt increments the lockout count
                await _userManager.AccessFailedAsync(user);

                return ResponseDTO<TokenDTO>.Fail(new List<ErrorDetail>
        {
            new ErrorDetail
            {
                Message = "Incorrect password.",
                Code = "InvalidPassword",
                Target = nameof(userLoginDTO.Password)
            }
        }, HttpStatusCode.BadRequest);
            }

            await _userManager.ResetAccessFailedCountAsync(user);

            var tokenDTO = await GenerateJwtToken(user);
            return ResponseDTO<TokenDTO>.Success(tokenDTO, HttpStatusCode.OK);
        }



        public async Task<ResponseDTO<NoContent>> RegisterSellerAsync(SellerRegisterDTO sellerRegisterDTO)
        {


            var existingUser = await _userManager.FindByEmailAsync(sellerRegisterDTO.Email);
            if (existingUser != null)
            {
                return ResponseDTO<NoContent>.Fail(new List<ErrorDetail>
        {
            new ErrorDetail
            {
                Message = "This email is already in use.",
                Code = "EmailInUse",
                Target = nameof(sellerRegisterDTO.Email)
            }
        }, HttpStatusCode.BadRequest);
            }


            var sellerUser = new Seller
            {
                UserName = sellerRegisterDTO.Email,
                Email = sellerRegisterDTO.Email,
         
                FirstName = sellerRegisterDTO.FirstName,
                LastName = sellerRegisterDTO.LastName,
                Address = sellerRegisterDTO.Address,
              
                DateOfBirth = sellerRegisterDTO.DateOfBirth,
                PhoneNumber = sellerRegisterDTO.PhoneNumber,
                IdentityNumber = sellerRegisterDTO.IdentityNumber,
                EmailConfirmed=true,
               

                StoreName = sellerRegisterDTO.StoreName
            };


            var createResult = await _userManager.CreateAsync(sellerUser, sellerRegisterDTO.Password);
            if (!createResult.Succeeded)
            {
                return ResponseDTO<NoContent>.Fail(createResult.Errors.Select(e => new ErrorDetail
                {
                    Message = e.Description,
                    Code = "UserCreationFailed",
                    Target = nameof(sellerRegisterDTO)
                }).ToList(), HttpStatusCode.BadRequest);
            }


            var addToRoleResult = await _userManager.AddToRoleAsync(sellerUser, "Seller");
            if (!addToRoleResult.Succeeded)
            {
                return ResponseDTO<NoContent>.Fail(addToRoleResult.Errors.Select(e => new ErrorDetail
                {
                    Message = e.Description,
                    Code = "RoleAssignmentFailed",
                    Target = nameof(sellerUser)
                }).ToList(), HttpStatusCode.BadRequest);
            }


            var createBasketResult = await _basketService.CreateBasketAsync(new BasketCreateDTO { ApplicationUserId = sellerUser.Id });
            if (!createBasketResult.IsSucceeded)
            {
                return ResponseDTO<NoContent>.Fail(new List<ErrorDetail>
        {
            new ErrorDetail
            {
                Message = "Failed to create a basket for the seller.",
                Code = "BasketCreationFailed",
                Target = nameof(sellerUser.Id)
            }
        }, HttpStatusCode.BadRequest);
            }

            return ResponseDTO<NoContent>.Success(HttpStatusCode.Created);
        }


      



        public async Task<ResponseDTO<NoContent>> RegisterUserAsync(UserRegisterDTO userRegisterDTO)
        {

            var existingUser = await _userManager.FindByEmailAsync(userRegisterDTO.Email);
            if (existingUser != null)
            {
                return ResponseDTO<NoContent>.Fail(new List<ErrorDetail>
        {
            new ErrorDetail
            {
                Message = "This email is already in use.",
                Code = "EmailInUse",
                Target = nameof(userRegisterDTO.Email)
            }
        }, HttpStatusCode.BadRequest);
            }

            var normalUser = new NormalUser
            {
                UserName = userRegisterDTO.Email,
                Email = userRegisterDTO.Email,
                FirstName = userRegisterDTO.FirstName,
                LastName = userRegisterDTO.LastName,
                PhoneNumber = userRegisterDTO.PhoneNumber,
              
                EmailConfirmed = true,
                Address = userRegisterDTO.Adress



            };


            var createResult = await _userManager.CreateAsync(normalUser, userRegisterDTO.Password);
            if (!createResult.Succeeded)
            {
                return ResponseDTO<NoContent>.Fail(createResult.Errors.Select(e => new ErrorDetail
                {
                    Message = e.Description,
                    Code = "UserCreationFailed",
                    Target = nameof(userRegisterDTO)
                }).ToList(), HttpStatusCode.BadRequest);
            }


            var addToRoleResult = await _userManager.AddToRoleAsync(normalUser, "NormalUser");
            if (!addToRoleResult.Succeeded)
            {
                return ResponseDTO<NoContent>.Fail(addToRoleResult.Errors.Select(e => new ErrorDetail
                {
                    Message = e.Description,
                    Code = "RoleAssignmentFailed",
                    Target = nameof(normalUser)
                }).ToList(), HttpStatusCode.BadRequest);
            }

            // Kullanıcıya ait sepet oluşturma
            var createBasketResult = await _basketService.CreateBasketAsync(new BasketCreateDTO { ApplicationUserId = normalUser.Id });
            if (!createBasketResult.IsSucceeded)
            {
                return ResponseDTO<NoContent>.Fail(new List<ErrorDetail>
        {
            new ErrorDetail
            {
                Message = "Failed to create a basket for the user.",
                Code = "BasketCreationFailed",
                Target = nameof(normalUser.Id)
            }
        }, HttpStatusCode.BadRequest);
            }
            await SendWelcomeEmailAsync(normalUser);

            return ResponseDTO<NoContent>.Success(HttpStatusCode.Created);
        }


        private async Task SendWelcomeEmailAsync(NormalUser user)
        {
            string subject = "Aramıza Hoşgeldiniz!";

            try
            {
                var templatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates", "RegisterTemplate.liquid");

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
                var userData = new Dictionary<string, object>
        {
            { "FirstName", user.FirstName },
            { "LastName", user.LastName },
            { "Email", user.Email }
        };

                templateContext.SetValue("user", userData);
                var body = template.Render(templateContext);

                await _emailService.SendEmailAsync(user.Email, subject, body);
            }
            catch (Exception ex)
            {
                Console.WriteLine("E-posta gönderme hatası: " + ex.Message);
                throw;
            }
        }


        private async Task<TokenDTO> GenerateJwtToken(ApplicationUser user)
        {

            var roles = await _userManager.GetRolesAsync(user);


            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier, user.Id),
        new Claim(ClaimTypes.Email, user.Email),
        new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };


            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));


            if (!string.IsNullOrEmpty(user.FirstName))
                claims.Add(new Claim("FirstName", user.FirstName));
            if (!string.IsNullOrEmpty(user.LastName))
                claims.Add(new Claim("LastName", user.LastName));
            claims.Add(new Claim("IsDeleted", user.IsDeleted.ToString()));


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfig.Secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


            var expiry = DateTime.Now.AddMinutes(_jwtConfig.AccessTokenExpiration);


            var token = new JwtSecurityToken(
                issuer: _jwtConfig.Issuer,
                audience: _jwtConfig.Audience,
                claims: claims,
                expires: expiry,
                signingCredentials: credentials
            );


            var tokenDTO = new TokenDTO
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                ExpirationDate = expiry,

            };

            return tokenDTO;
        }

     

    }
}
