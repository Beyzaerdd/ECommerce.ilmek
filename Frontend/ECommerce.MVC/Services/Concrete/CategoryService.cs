using ECommerce.MVC.Models.CategoryModels;
using ECommerce.MVC.Services.Abstract;
using ECommerce.MVC.Views.Shared.ResponseViewModels;
using System.Text.Json;

namespace ECommerce.MVC.Services.Concrete
{
    public class CategoryService : BaseService, ICategoryService
    {
        public CategoryService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor) : base(httpClientFactory, httpContextAccessor) { }

        public Task<ResponseViewModel<IEnumerable<CategoryModel>>> GetActiveCategoriesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseViewModel<IEnumerable<CategoryModel>>> GetAllCategoriesAsync()
        {
            throw new NotImplementedException();
        }


        public async Task<ResponseViewModel<IEnumerable<CategoryModel>>> GetCategoriesByParent()
        {
            var client = GetHttpClient();
            var fullUrl = new Uri(client.BaseAddress, "categories/GetCategoriesByParent");

            var response = await client.GetAsync(fullUrl);
            var responseBody = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = !string.IsNullOrEmpty(responseBody) ? responseBody : "Kategoriler alınırken hata oluştu.";

                return new ResponseViewModel<IEnumerable<CategoryModel>>
                {
                    IsSucceeded = false,
                    Errors = new List<ErrorViewModel>
            {
                new ErrorViewModel { Message = $"Hata: {errorMessage}" }
            }
                };
            }

            var result = JsonSerializer.Deserialize<ResponseViewModel<IEnumerable<CategoryModel>>>(responseBody, _jsonSerializerOptions);

            if (result == null || !result.IsSucceeded)
            {
                return new ResponseViewModel<IEnumerable<CategoryModel>>
                {
                    IsSucceeded = false,
                    Errors = result?.Errors ?? new List<ErrorViewModel>
            {
                new ErrorViewModel { Message = "API'den geçerli veri alınamadı." }
            }
                };
            }

            return new ResponseViewModel<IEnumerable<CategoryModel>>
            {
                IsSucceeded = true,
                Data = result.Data 
            };
        }




        public Task<ResponseViewModel<CategoryModel>> GetCategoriesByParentIdAsync(int? parentId)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseViewModel<CategoryModel>> GetCategoryByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseViewModel<int>> GetCategoryCountAsync()
        {
            throw new NotImplementedException();
        }
    }
}
