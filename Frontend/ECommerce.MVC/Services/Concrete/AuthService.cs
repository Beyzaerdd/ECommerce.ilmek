using ECommerce.MVC.Models.AuthModels;
using ECommerce.MVC.Services.Abstract;
using ECommerce.MVC.Views.Shared.ResponseViewModels;
using ECommerce.Shared.DTOs.ResponseDTOs;
using System.Text.Json;

namespace ECommerce.MVC.Services.Concrete
{
    public class AuthService : BaseService, IAuthService
    {
        public AuthService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor) : base(httpClientFactory, httpContextAccessor) { }




        public async Task<ResponseViewModel<NoContentViewModel>> ChangePasswordAsync(ChangePasswordModel changePasswordModel)
        {
            var client = GetHttpClient();
            var response = await client.PostAsJsonAsync("auth/ChangePassword", changePasswordModel);
            var responseBody = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode || string.IsNullOrEmpty(responseBody))
            {
                return new ResponseViewModel<NoContentViewModel>
                {
                    IsSucceeded = false,
                    Errors = new List<ErrorViewModel>
                {
                    new ErrorViewModel
                    {
                        Message = "Şifre değiştirme başarısız, lütfen tekrar deneyin."
                    }
                }
                };
            }

            var result = JsonSerializer.Deserialize<ResponseViewModel<NoContentViewModel>>(responseBody, _jsonSerializerOptions);

            if (result?.Data == null)
            {
                return new ResponseViewModel<NoContentViewModel>
                {
                    IsSucceeded = false,
                    Errors = new List<ErrorViewModel>
                {
                    new ErrorViewModel
                    {
                        Message = "Şifre değiştirme sırasında bir hata oluştu."
                    }
                }
                };
            }

            return result;
        
    }

        public async Task<ResponseViewModel<NoContentViewModel>> ForgotPasswordAsync(ForgotPasswordModel forgotPasswordModel)
        {
            var client = GetHttpClient();
            var response = await client.PostAsJsonAsync("auth/ForgotPassword", forgotPasswordModel);
            var responseBody = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode || string.IsNullOrEmpty(responseBody))
            {
                return new ResponseViewModel<NoContentViewModel>
                {
                    IsSucceeded = false,
                    Errors = new List<ErrorViewModel>
                {
                    new ErrorViewModel
                    {
                        Message = "Şifre sıfırlama isteği başarısız, lütfen tekrar deneyin."
                    }
                }
                };
            }

            var result = JsonSerializer.Deserialize<ResponseViewModel<NoContentViewModel>>(responseBody, _jsonSerializerOptions);

            if (result?.Data == null)
            {
                return new ResponseViewModel<NoContentViewModel>
                {
                    IsSucceeded = false,
                    Errors = new List<ErrorViewModel>
                {
                    new ErrorViewModel
                    {
                        Message = "Şifre sıfırlama sırasında bir hata oluştu."
                    }
                }
                };
            }

            return result;
        }

        public async Task<ResponseViewModel<TokenModel>> LoginSellerAsync(LoginSellerModel sellerLoginModel)
        {
            var client = GetHttpClient();
            var response = await client.PostAsJsonAsync("auth/LoginSeller", sellerLoginModel);
            var responseBody = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode || string.IsNullOrEmpty(responseBody))
            {
                return new ResponseViewModel<TokenModel>
                {
                    IsSucceeded = false,
                    Errors = new List<ErrorViewModel>
                {
                    new ErrorViewModel
                    {
                        Message = "Satıcı girişi başarısız, lütfen tekrar deneyin."
                    }
                }
                };
            }

            var result = JsonSerializer.Deserialize<ResponseViewModel<TokenModel>>(responseBody, _jsonSerializerOptions);

            if (result?.Data == null)
            {
                return new ResponseViewModel<TokenModel>
                {
                    IsSucceeded = false,
                    Errors = new List<ErrorViewModel>
                {
                    new ErrorViewModel
                    {
                        Message = "Geçersiz satıcı giriş bilgileri."
                    }
                }
                };
            }

            return result;
        }

        public async Task<ResponseViewModel<TokenModel>> LoginUserAsync(LoginUserModel userLoginModel)
        {
            var client = GetHttpClient();
            var response = await client.PostAsJsonAsync("auth/LoginUser", userLoginModel);
            var responseBody = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode || string.IsNullOrEmpty(responseBody))
            {
                return new ResponseViewModel<TokenModel>
                {
                    IsSucceeded = false,
                    Errors = new List<ErrorViewModel>
                {
                    new ErrorViewModel
                    {
                        Message = "Giriş başarısız, lütfen tekrar deneyin."
                    }
                }
                };
            }

            var result = JsonSerializer.Deserialize<ResponseViewModel<TokenModel>>(responseBody, _jsonSerializerOptions);

            if (result?.Data == null)
            {
                return new ResponseViewModel<TokenModel>
                {
                    IsSucceeded = false,
                    Errors = new List<ErrorViewModel>
                {
                    new ErrorViewModel
                    {
                        Message = "Geçersiz giriş bilgileri."
                    }
                }
                };
            }

            return result;
        
    }

        public async Task<ResponseViewModel<string>> RegisterSellerAsync(RegisterSellerModel sellerRegisterModel)
        {
            var client = GetHttpClient();
            var response = await client.PostAsJsonAsync("auth/RegisterSeller", sellerRegisterModel);
            var responseBody = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode || string.IsNullOrEmpty(responseBody))
            {
                return new ResponseViewModel<string>
                {
                    IsSucceeded = false,
                    Errors = new List<ErrorViewModel>
                {
                    new ErrorViewModel
                    {
                        Message = "Satıcı kaydı başarısız, lütfen tekrar deneyin."
                    }
                }
                };
            }
          
            var result = JsonSerializer.Deserialize<ResponseViewModel<string>>(responseBody, _jsonSerializerOptions);

           

            return result;
        
    }
    

        public async Task<ResponseViewModel<NoContentViewModel>> RegisterUserAsync(RegisterUserModel userRegisterModel)
        {
            var client = GetHttpClient();
            var response = await client.PostAsJsonAsync("auth/RegisterUser", userRegisterModel);
            var responseBody = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode || string.IsNullOrEmpty(responseBody))
            {
                return new ResponseViewModel<NoContentViewModel>
                {
                    IsSucceeded = false,
                    Errors = new List<ErrorViewModel>
                {
                    new ErrorViewModel
                    {
                        Message = "Kayıt başarısız, lütfen tekrar deneyin."
                    }
                }
                };
            }

            var result = JsonSerializer.Deserialize<ResponseViewModel<NoContentViewModel>>(responseBody, _jsonSerializerOptions);

            if (result?.Data == null)
            {
                return new ResponseViewModel<NoContentViewModel>
                {
                    IsSucceeded = false,
                    Errors = new List<ErrorViewModel>
                {
                    new ErrorViewModel
                    {
                        Message = "Kayıt sırasında bir hata oluştu."
                    }
                }
                };
            }

            return result;
        }
    }
    }

