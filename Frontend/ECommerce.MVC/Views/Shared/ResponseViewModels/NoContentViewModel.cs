using System.Net;

namespace ECommerce.MVC.Views.Shared.ResponseViewModels
{
    public class NoContentViewModel
    {
        public bool IsSucceeded { get; set; }

        public static NoContentViewModel FromApiResponse(HttpResponseMessage response)
        {
            return new NoContentViewModel
            {
                IsSucceeded = response.StatusCode == HttpStatusCode.NoContent
            };
        }
    }
}
