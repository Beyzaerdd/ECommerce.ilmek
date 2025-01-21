using ECommerce.Shared.DTOs.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Shared.Extensions
{
    public static class ResponseExtensions
    {
        public static bool HasErrors(this ResponseDTO<object> response)
        {
            return response.Errors != null && response.Errors.Any();
        }

        public static string? GetFirstErrorMessage(this ResponseDTO<object> response)
        {
            return response.Errors?.FirstOrDefault()?.Message;
        }
    }
}
