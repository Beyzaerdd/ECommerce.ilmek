using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Shared.DTOs.ResponseDTOs
{
    public class ErrorDetail
    {
        public string Message { get; set; } 
        public string? Code { get; set; } 
        public string? Target { get; set; }


    }
}
