using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ECommerce.Shared.DTOs.ResponseDTOs
{
    public class ResponseDTO<T>
    { 
     public T? Data { get; set; } 

    public List<ErrorDetail>? Errors { get; set; }

    [JsonPropertyName("success")]
    public bool IsSucceeded { get; set; } 

    [JsonPropertyName("status_code")]
    public HttpStatusCode StatusCode { get; set; } 

  
    public static ResponseDTO<T> Success(T data, HttpStatusCode statusCode)
    {
        return new ResponseDTO<T>
        {
            Data = data,
            StatusCode = statusCode,
            IsSucceeded = true,
     
        };
    }

    public static ResponseDTO<T> Success(HttpStatusCode statusCode)
    {
        return new ResponseDTO<T>
        {
            Data = default,
            StatusCode = statusCode,
            IsSucceeded = true,
   
        };
    }


    public static ResponseDTO<T> Fail(string error, HttpStatusCode statusCode)
    {
        return new ResponseDTO<T>
        {
            Errors = new List<ErrorDetail> { new ErrorDetail { Message = error } },
            StatusCode = statusCode,
            IsSucceeded = false
        };
    }

    public static ResponseDTO<T> Fail(List<ErrorDetail> errors, HttpStatusCode statusCode)
    {
        return new ResponseDTO<T>
        {
            Errors = errors,
            StatusCode = statusCode,
            IsSucceeded = false
        };
    }
}
      
}
