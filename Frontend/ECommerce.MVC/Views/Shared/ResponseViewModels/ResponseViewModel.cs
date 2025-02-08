using ECommerce.Shared.DTOs.ResponseDTOs;
using System.Text.Json.Serialization;

namespace ECommerce.MVC.Views.Shared.ResponseViewModels
{
    public class ResponseViewModel<T>
    {
        [JsonPropertyName("data")]
        public T? Data { get; set; }

        [JsonPropertyName("errors")]
        public List<ErrorViewModel>? Errors { get; set; }

        [JsonPropertyName("success")]
        public bool IsSucceeded { get; set; }

        public static ResponseViewModel<T> FromApiResponse(ResponseDTO<T> apiResponse)
        {
            return new ResponseViewModel<T>
            {
                Data = apiResponse.Data,
                Errors = apiResponse.Errors?.ConvertAll(e => new ErrorViewModel
                {
                    Message = e.Message,
                    Code = e.Code,
                    Target = e.Target
                }),
                IsSucceeded = apiResponse.IsSucceeded
            };
        }
    }
}
}
