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
        [HttpGet]
        public async Task<IActionResult> LoginSeller()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> RegisterSeller()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> RegisterUser()
        {
            return View();
        }




        [HttpPost("LoginUser")]
        public async Task<IActionResult> LoginUser(LoginUserModel loginUserModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "Lütfen tüm alanları doğru şekilde doldurduğunuzdan emin olun.";
                return View(loginUserModel);
            }

            try
            {
                var response = await _authService.LoginUserAsync(loginUserModel);

                if (response.IsSucceeded)
                {
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
                        if (TempData["PendingProductId"] != null && TempData["PendingQuantity"] != null)
                        {
                            string returnController = TempData["ReturnController"] as string ?? string.Empty;
                            string returnAction = TempData["ReturnAction"] as string ?? string.Empty;
                            int pendingProductId = TempData["PendingProductId"] as int? ?? 0;
                            int pendingQuantity = TempData["PendingQuantity"] as int? ?? 0;

                            return RedirectToAction(returnAction, returnController, new
                            {
                                productId = pendingProductId,
                                quantity = pendingQuantity
                            });
                        }
                    }
                   _toaster.AddSuccessToastMessage("Hoşgeldiniz! Giriş işlemi başarıyla tamamlandı.");

                        return RedirectToAction("Index", "Home");
                    }


                _toaster.AddErrorToastMessage("Giriş hatası, lütfen şifrenizi kontrol edin.");
                ViewBag.ErrorMessage = "Yanlış e-posta veya şifre.";
                return View(loginUserModel);
            }
            catch (Exception ex)
            {
                _toaster.AddErrorToastMessage($"Bir hata oluştu: {ex.Message}");
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
                return View(registerUserModel);
            }

            try
            {
                var response = await _authService.RegisterUserAsync(registerUserModel);

                if (response.IsSucceeded)
                {
                    _toaster.AddSuccessToastMessage("Kayıt işlemi başarıyla tamamlandı.");
                    return RedirectToAction("LoginUser");
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

        // Satıcı Girişi
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

                if (response.IsSucceeded)
                {
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
                        return RedirectToAction("Index", "Home");
                    }
                }

                _toaster.AddErrorToastMessage("Satıcı girişi hatası.");
                ViewBag.ErrorMessage = "Yanlış e-posta veya şifre.";
                return View(loginSellerModel);
            }
            catch (Exception ex)
            {
                _toaster.AddErrorToastMessage($"Bir hata oluştu: {ex.Message}");
                return View(loginSellerModel);
            }
        }

        // Satıcı Kayıt
        [HttpPost("RegisterSeller")]
        public async Task<IActionResult> RegisterSeller(RegisterSellerModel registerSellerModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registerSellerModel);
            }

            try
            {
                var response = await _authService.RegisterSellerAsync(registerSellerModel);

                if (response.IsSucceeded)
                {
                    _toaster.AddSuccessToastMessage("Mağazanız başarıyla oluşturulmuştur. Onaylandıktan sonra size bir e-posta gönderilecektir.");

                    return Redirect("/Auth/LoginSeller");

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

                return View(registerSellerModel);
            }
            
            catch (Exception ex)
            {
                _toaster.AddErrorToastMessage($"Bir hata oluştu: {ex.Message}");
                return View(registerSellerModel);
            }
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
                    return RedirectToAction("LoginUser");
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
                    return RedirectToAction("LoginUser");
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
    }
}
