using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ECommerce.Shared.DTOs.ResponseDTOs
{
    public class ResponseDTO<T>
    {
        public T? Data { get; set; }
        public List<string>? Errors { get; set; }

        [JsonIgnore]
        public bool IsSucceded { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; }


        public static ResponseDTO<T> Success(T data, int statusCode)
        {
            return new ResponseDTO<T>
            {
                Data = data,
                StatusCode = statusCode,
                IsSucceded = true
            };
        }

       
        public static ResponseDTO<T> Success(int statusCode)
        {
            return new ResponseDTO<T>
            {
                Data = default(T),
                StatusCode = statusCode,
                IsSucceded = true
            };
        }

      
        public static ResponseDTO<T> Fail(string error, int statusCode)
        {
            return new ResponseDTO<T>
            {
                Errors = new List<string> { error },
                StatusCode = statusCode,
                IsSucceded = false
            };
        }

     
        public static ResponseDTO<T> Fail(List<string> errors, int statusCode)
        {
            return new ResponseDTO<T>
            {
                Errors = errors,
                StatusCode = statusCode,
                IsSucceded = false
            };
        }
    }
}
