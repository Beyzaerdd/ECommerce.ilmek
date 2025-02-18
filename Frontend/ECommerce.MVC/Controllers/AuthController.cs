using ECommerce.MVC.Models.AuthModels;
using ECommerce.MVC.Services.Abstract;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;


namespace ECommerce.MVC.Controllers
{
   
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IToastNotification _toaster;
        public AuthController(IAuthService authService, IToastNotification toaster)
        {
            _authService = authService;
            _toaster = toaster;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> LoginUser()
        {
            return View();
        }
    
        public async Task<IActionResult> LoginSeller()
        {
            return View();
        }

      
        public async Task<IActionResult> RegisterSeller()
        {
            return View();
        }
    
        public async Task<IActionResult> RegisterUser()
        {
            return View();
        }


        public async Task<IActionResult> ForgotPassword()
        {
            return View();
        }


      
        public IActionResult ResetPassword(string token, string email)
        {
            if (string.IsNullOrEmpty(token) || string.IsNullOrEmpty(email))
            {
                return BadRequest("Geçersiz istek.");
            }

            
            return View();
        }



        [HttpPost("LoginUser")]
        public async Task<IActionResult> LoginUser(LoginUserModel loginUserModel, string returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Lütfen tüm alanları doğru şekilde doldurduğunuzdan emin olun.");
                return View(loginUserModel);
            }

            try
            {
                var response = await _authService.LoginUserAsync(loginUserModel);

                if (response.IsSucceeded && response.Data?.AccessToken != null)
                {
                    var handler = new JwtSecurityTokenHandler();
                    var token = handler.ReadJwtToken(response.Data.AccessToken);

                    var userName = token.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
                    var userId = token.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                    var role = token.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

                    if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(userId))
                    {
                        var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, userName),
                    new Claim(ClaimTypes.Name, userName),
                    new Claim(ClaimTypes.NameIdentifier, userId),
                    new Claim(ClaimTypes.Role, role ?? string.Empty),
                    new Claim("AccessToken", response.Data.AccessToken)
                };

                        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var principal = new ClaimsPrincipal(identity);

                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties
                        {
                            ExpiresUtc = response.Data.ExpirationDate,
                            IsPersistent = true
                        });

                        _toaster.AddSuccessToastMessage("Hoşgeldiniz! Giriş işlemi başarıyla tamamlandı.");

                        if (!string.IsNullOrEmpty(returnUrl))
                        {
                            return Redirect(returnUrl);
                        }

                        return RedirectToAction("Index", "Home");
                    }
                }

                var errorMessage = response.Errors?.FirstOrDefault()?.Message ?? "Giriş hatası, lütfen şifrenizi kontrol edin.";

                _toaster.AddErrorToastMessage(errorMessage);
                ModelState.AddModelError(string.Empty, errorMessage);

                return View(loginUserModel);
            }
            catch (Exception ex)
            {
                _toaster.AddErrorToastMessage($"Bir hata oluştu: {ex.Message}");
                ModelState.AddModelError(string.Empty, "Bir hata oluştu, lütfen daha sonra tekrar deneyin.");
                return View(loginUserModel);
            }
        }


        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            _toaster.AddSuccessToastMessage("Çıkış işlemi başarıyla tamamlandı");
            return RedirectToAction("Index", "Home");
        }

        [HttpPost("RegisterUser")]
        public async Task<IActionResult> RegisterUser(RegisterUserModel registerUserModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Lütfen tüm alanları doğru şekilde doldurduğunuzdan emin olun.");
                return View(registerUserModel);
            }

            try
            {
                var response = await _authService.RegisterUserAsync(registerUserModel);

                if (response.IsSucceeded)
                {
                    _toaster.AddSuccessToastMessage("Tebrikler! Kayıt işlemi başarıyla tamamlandı.");
                    return Redirect("/Auth/LoginUser");
                }

                _toaster.AddErrorToastMessage("Kayıt hatası, lütfen tekrar deneyin.");
                return View(registerUserModel);
            }
            catch (Exception ex)
            {
                _toaster.AddErrorToastMessage($"Bir hata oluştu: {ex.Message}");
                return View(registerUserModel);
            }
        }

        [HttpPost("LoginSeller")]
        public async Task<IActionResult> LoginSeller(LoginSellerModel loginSellerModel)
        {
            if (!ModelState.IsValid)
            {
               
                return View(loginSellerModel);
            }

            try
            {
                var response = await _authService.LoginSellerAsync(loginSellerModel);

                if (!response.IsSucceeded)
                {
                
                    var errorMessage = response.Errors?.FirstOrDefault()?.Message ?? "Yanlış e-posta veya şifre.";
                    ModelState.AddModelError(string.Empty, errorMessage); 
                    _toaster.AddErrorToastMessage(errorMessage); 
                    return View(loginSellerModel);
                }

                var handler = new JwtSecurityTokenHandler();
                var token = handler.ReadJwtToken(response.Data.AccessToken);
                var userName = token.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
                var userId = token.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                var role = token.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

                if (userName != null)
                {
                    var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, userName),
                new Claim(ClaimTypes.Name, userName),
                new Claim(ClaimTypes.NameIdentifier, userId ?? string.Empty),
                new Claim(ClaimTypes.Role, role ?? string.Empty),
                new Claim("AccessToken", response.Data.AccessToken)
            };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        principal,
                        new AuthenticationProperties
                        {
                            ExpiresUtc = response.Data.ExpirationDate,
                            IsPersistent = true
                        });

                    _toaster.AddSuccessToastMessage("Satıcı girişi başarıyla tamamlandı.");

                    //TODO dashboardda yönlendirilecek
                    return RedirectToAction("Index", "Home");
                }

                _toaster.AddErrorToastMessage("Beklenmeyen bir hata oluştu. Lütfen tekrar deneyin.");
                return View(loginSellerModel);
            }
            catch (Exception ex)
            {
                _toaster.AddErrorToastMessage("Bir hata oluştu: " + ex.Message);
                return View(loginSellerModel);
            }
        }


        // Satıcı Kayıt
        [HttpPost("RegisterSeller")]
        public async Task<IActionResult> RegisterSeller(RegisterSellerModel registerSellerModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Lütfen tüm alanları doğru şekilde doldurduğunuzdan emin olun.");
                return View(registerSellerModel);
            }

            try
            {
                var response = await _authService.RegisterSellerAsync(registerSellerModel);

                if (response.IsSucceeded)
                {
                    _toaster.AddSuccessToastMessage("Mağazanız başarıyla oluşturulmuştur. Onaylandıktan sonra size bir e-posta gönderilecektir.");

                    return RedirectToAction("RegistrationSuccess");

                }


                if (response.Errors != null && response.Errors.Any())
                {
                    foreach (var error in response.Errors)
                    {
                        ModelState.AddModelError(error.Target ?? "", error.Message);
                    }
                }
                else
                {
                
                    ModelState.AddModelError("", "Kayıt sırasında bir hata oluştu.");
                }

                return RedirectToAction("RegistrationSuccess");
            }
            
            catch (Exception ex)
            {
                _toaster.AddErrorToastMessage($"Bir hata oluştu: {ex.Message}");
                return View(registerSellerModel);
            }
        }
        public IActionResult RegistrationSuccess()
        {
            return View();
        }
        // Şifre Sıfırlama
        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordModel forgotPasswordModel)
        {
            if (!ModelState.IsValid)
            {
                return View(forgotPasswordModel);
            }

            try
            {
                var response = await _authService.ForgotPasswordAsync(forgotPasswordModel);

                if (response.IsSucceeded)
                {
                    _toaster.AddSuccessToastMessage("Şifre sıfırlama talebi başarıyla gönderildi.");
                    return Redirect("/Auth/LoginUser");
                }

                _toaster.AddErrorToastMessage("Şifre sıfırlama hatası.");
                return View(forgotPasswordModel);
            }
            catch (Exception ex)
            {
                _toaster.AddErrorToastMessage($"Bir hata oluştu: {ex.Message}");
                return View(forgotPasswordModel);
            }
        }

        // Şifre Değiştirme
        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel changePasswordModel)
        {
            if (!ModelState.IsValid)
            {
                return View(changePasswordModel);
            }

            try
            {
                var response = await _authService.ChangePasswordAsync(changePasswordModel);

                if (response.IsSucceeded)
                {
                    _toaster.AddSuccessToastMessage("Şifre başarıyla değiştirildi.");
                    return RedirectToAction("Index", "Home");
                }

                _toaster.AddErrorToastMessage("Şifre değiştirme hatası.");
                return View(changePasswordModel);
            }
            catch (Exception ex)
            {
                _toaster.AddErrorToastMessage($"Bir hata oluştu: {ex.Message}");
                return View(changePasswordModel);
            }
        }

        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel resetPasswordModel)
        {
            if (!ModelState.IsValid)
            {
                return View(resetPasswordModel);
            }

            try
            {
                var response = await _authService.ResetPasswordAsync(resetPasswordModel);

                if (response.IsSucceeded)
                {
                    _toaster.AddSuccessToastMessage("Şifre başarıyla değiştirildi.");
                    return Redirect("/Auth/LoginUser");
                }

                _toaster.AddErrorToastMessage("Şifre sıfırlama hatası.");
                return View(resetPasswordModel);
            }
            catch (Exception ex)
            {
                _toaster.AddErrorToastMessage($"Bir hata oluştu: {ex.Message}");
                return View(resetPasswordModel);
            }
        }
    }
}
