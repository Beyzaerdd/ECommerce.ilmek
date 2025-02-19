using ECommerce.MVC.Models.ContactMessageModels;
using ECommerce.MVC.Models.ReviewModels;
using ECommerce.MVC.Services.Abstract;
using ECommerce.MVC.Views.Shared.ResponseViewModels;
using System.Text.Json;

namespace ECommerce.MVC.Services.Concrete
{
    public class ContactMessageService : BaseService, IContactMessageService
    {
        public ContactMessageService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor) : base(httpClientFactory, httpContextAccessor) { }
        public async Task<ResponseViewModel<NoContentViewModel>> AddContactMessageAsync(ContactMessageCreateModel contactMessageCreateModel)
        {
            var client = GetHttpClient();
            var response = await client.PostAsJsonAsync("ContactMessages/send", contactMessageCreateModel);
            var responseBody = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode || string.IsNullOrEmpty(responseBody))
            {
                return new ResponseViewModel<NoContentViewModel>
                {
                    IsSucceeded = false,
                    Errors = new List<ErrorViewModel>
            {
                new ErrorViewModel { Message = "Mesaj gönderirken bir hata oluştu." }
            }
                };
            }

            var result = JsonSerializer.Deserialize<ResponseViewModel<NoContentViewModel>>(responseBody, _jsonSerializerOptions);
            return result ?? new ResponseViewModel<NoContentViewModel> { IsSucceeded = false, Errors = new List<ErrorViewModel> { new ErrorViewModel { Message = "API'den geçerli veri alınamadı." } } };
        }
    }
}
