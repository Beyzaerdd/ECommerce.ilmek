using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Shared.Extensions
{
    public static class HttpContextExtensions
    {
        public static string GetUserId(this Microsoft.AspNetCore.Http.IHttpContextAccessor contextAccessor)
        {
            return contextAccessor.HttpContext.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
        }

    }
}
