﻿using System;
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
            var userIdClaim = contextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

            if (userIdClaim == null)
            {
                throw new InvalidOperationException("User ID claim not found in the HTTP context.");
            }

            return userIdClaim.Value;

        }

    }
}
