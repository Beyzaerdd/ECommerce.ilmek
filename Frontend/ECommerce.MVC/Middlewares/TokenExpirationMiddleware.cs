using Microsoft.AspNetCore.Authentication;
using System.IdentityModel.Tokens.Jwt;

namespace ECommerce.MVC.Middlewares
{
    public class TokenExpirationMiddleware
    {
        private readonly RequestDelegate _next;

        public TokenExpirationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var token = context.User.Claims.FirstOrDefault(c => c.Type == "AccessToken")?.Value;

            if (!string.IsNullOrEmpty(token))
            {
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadToken(token) as JwtSecurityToken;

                if (jwtToken != null && jwtToken.ValidTo < DateTime.UtcNow)
                {
                    await context.SignOutAsync();
                    context.Response.Cookies.Append("SessionExpired", "true", new CookieOptions
                    {
                        Expires = DateTime.UtcNow.AddMinutes(1), 
                        HttpOnly = true,
                        Secure = true,
                        SameSite = SameSiteMode.Strict
                    });
                    context.Response.Redirect("/Auth/Loginuser?sessionExpired=true");
                    return;
                }
            }

            await _next(context);
        }
    }


}
    
