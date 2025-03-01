using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ECommerce.MVC.Areas.Admin.Helpers
{
    public class UserHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public List<string> GetUserRoles()
        {
            var token = _httpContextAccessor.HttpContext?.Request.Cookies["ECommerce.Auth"];
            if (string.IsNullOrEmpty(token))
                return new List<string>();

            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);
            var roles = jwtToken.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).ToList();

            return roles;
        }
    }
}
