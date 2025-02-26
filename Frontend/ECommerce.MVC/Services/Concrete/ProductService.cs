
using ECommerce.MVC.Models.EnumResponseModels;
using ECommerce.MVC.Models.ProductModels;
using ECommerce.MVC.Services.Abstract;
using ECommerce.MVC.Views.Shared.ResponseViewModels;
using ECommerce.Shared.ComplexTypes;
using System.Globalization;
using System.Text.Json;

namespace ECommerce.MVC.Services.Concrete
{
    public class ProductService : BaseService, IProductService
    {
        public ProductService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor, ILogger<ProductService> logger) : base(httpClientFactory, httpContextAccessor)
        {
            _logger = logger;
        }
        private readonly ILogger<ProductService> _logger;



        public async Task<ResponseViewModel<IEnumerable<ProductModel>>> GetProductBySellerAsync(string applicationUserId, int count = 8)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.GetAsync($"products/getBySeller?applicationUserId={applicationUserId}&take={count}");

                if (!response.IsSuccessStatusCode)
                {
                    return new ResponseViewModel<IEnumerable<ProductModel>>
                    {
                        IsSucceeded = false,
                        Errors = new List<ErrorViewModel>
                {
                    new ErrorViewModel { Message = "Ürünler getirilirken bir hata oluştu. Hata kodu: " + response.StatusCode }
                }
                    };
                }

                var responseBody = await response.Content.ReadAsStringAsync();
                if (string.IsNullOrEmpty(responseBody))
                {
                    return new ResponseViewModel<IEnumerable<ProductModel>>
                    {
                        IsSucceeded = false,
                        Errors = new List<ErrorViewModel> { new ErrorViewModel { Message = "API'den geçerli veri alınamadı." } }
                    };
                }

                var result = JsonSerializer.Deserialize<ResponseViewModel<IEnumerable<ProductModel>>>(responseBody, _jsonSerializerOptions);

                return result ?? new ResponseViewModel<IEnumerable<ProductModel>>
                {
                    IsSucceeded = false,
                    Errors = new List<ErrorViewModel> { new ErrorViewModel { Message = "Veri deserialize edilemedi." } }
                };
            }
            catch (Exception ex)
            {
                return new ResponseViewModel<IEnumerable<ProductModel>>
                {
                    IsSucceeded = false,
                    Errors = new List<ErrorViewModel>
            {
                new ErrorViewModel { Message = "Bir hata oluştu: " + ex.Message }
            }
                };
            }
        }






        public async Task<ResponseViewModel<IEnumerable<ProductModel>>> GetAllProductAsync(int count = 8)
        {
            var client = GetHttpClient();
            var response = await client.GetAsync($"products/getAll?take={count}");
            var responseBody = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode || string.IsNullOrEmpty(responseBody))
            {
                return new ResponseViewModel<IEnumerable<ProductModel>>
                {
                    IsSucceeded = false,
                    Errors = new List<ErrorViewModel>
                {
                    new ErrorViewModel { Message = "Ürünler getirilirken bir hata oluştu." }
                }
                };
            }

            var result = JsonSerializer.Deserialize<ResponseViewModel<IEnumerable<ProductModel>>>(responseBody, _jsonSerializerOptions);

            return result ?? new ResponseViewModel<IEnumerable<ProductModel>>
            {
                IsSucceeded = false,
                Errors = new List<ErrorViewModel> { new ErrorViewModel { Message = "API'den geçerli veri alınamadı." } }
            };
        }


        public async Task<ResponseViewModel<IEnumerable<ProductModel>>> GetCategoriesByParent()
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseViewModel<int>> getCountByCategory(int? categoryId)
        {
            var client = GetHttpClient();
            var response = await client.GetAsync($"products/GetCountByCategory?categoryId={categoryId}");
            var responseBody = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode || string.IsNullOrEmpty(responseBody))
            {
                return new ResponseViewModel<int>
                {
                    IsSucceeded = false,
                    Errors = new List<ErrorViewModel>
                {
                    new ErrorViewModel { Message = "Kategoriye ait ürün sayısı alınırken hata oluştu." }
                }
                };
            }

            var result = JsonSerializer.Deserialize<ResponseViewModel<int>>(responseBody, _jsonSerializerOptions);

            return result ?? new ResponseViewModel<int>
            {
                IsSucceeded = false,
                Errors = new List<ErrorViewModel> { new ErrorViewModel { Message = "API'den geçerli veri alınamadı." } }
            };
        }

        public async Task<ResponseViewModel<ProductModel>> GetProductByIdAsync(int id)
        {
            var client = GetHttpClient();
            var response = await client.GetAsync($"products/GetProductBy/{id}");
            var responseBody = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode || string.IsNullOrEmpty(responseBody))
            {
                return new ResponseViewModel<ProductModel>
                {
                    IsSucceeded = false,
                    Errors = new List<ErrorViewModel>
                {
                    new ErrorViewModel { Message = "Ürün bilgisi alınırken hata oluştu." }
                }
                };
            }

            var result = JsonSerializer.Deserialize<ResponseViewModel<ProductModel>>(responseBody, _jsonSerializerOptions);

            return result ?? new ResponseViewModel<ProductModel>
            {
                IsSucceeded = false,
                Errors = new List<ErrorViewModel> { new ErrorViewModel { Message = "API'den geçerli veri alınamadı." } }
            };
        }
        public async Task<ResponseViewModel<IEnumerable<ProductModel>>> GetProductsByCategory(int? categoryId)
        {
            var client = GetHttpClient();
            var response = await client.GetAsync($"Products/getByCategory/{categoryId}");

            var responseBody = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode || string.IsNullOrEmpty(responseBody))
            {
                return new ResponseViewModel<IEnumerable<ProductModel>>
                {
                    IsSucceeded = false,
                    Errors = new List<ErrorViewModel>
                {
                    new ErrorViewModel { Message = "Belirtilen kategoriye ait ürünler getirilirken hata oluştu." }
                }
                };
            }

            var result = JsonSerializer.Deserialize<ResponseViewModel<IEnumerable<ProductModel>>>(responseBody, _jsonSerializerOptions);

            return result ?? new ResponseViewModel<IEnumerable<ProductModel>>
            {
                IsSucceeded = false,
                Errors = new List<ErrorViewModel> { new ErrorViewModel { Message = "API'den geçerli veri alınamadı." } }
            };
        }

        public async Task<ResponseViewModel<IEnumerable<ProductModel>>> FilterProducts(
        int categoryId, List<int>? selectedSizes, List<int>? selectedColors, decimal? minPrice, decimal? maxPrice)
        {
            var client = GetHttpClient();

         
            var queryParams = new List<string> { $"categoryId={categoryId}" };

            if (selectedSizes != null && selectedSizes.Any())
            {
                queryParams.AddRange(selectedSizes.Select(size => $"productSizes={size}"));
            }

            if (selectedColors != null && selectedColors.Any())
            {
                queryParams.AddRange(selectedColors.Select(color => $"productColors={color}"));
            }

            if (minPrice.HasValue)
            {
                queryParams.Add($"minPrice={minPrice.Value.ToString(CultureInfo.InvariantCulture)}");
            }

            if (maxPrice.HasValue)
            {
                queryParams.Add($"maxPrice={maxPrice.Value.ToString(CultureInfo.InvariantCulture)}");
            }

   
            var url = $"products/filterProducts?{string.Join("&", queryParams)}";

            _logger.LogInformation($"API Request: {client.BaseAddress}{url}");

            var response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                _logger.LogError($"API Error: {response.StatusCode} - {errorContent}");

                return new ResponseViewModel<IEnumerable<ProductModel>>
                {
                    IsSucceeded = false,
                    Errors = new List<ErrorViewModel>
            {
                new ErrorViewModel { Message = $"API Error: {response.StatusCode} - {errorContent}" }
            }
                };
            }

            var responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<ResponseViewModel<IEnumerable<ProductModel>>>(
                responseBody, _jsonSerializerOptions);

            if (result == null || !result.IsSucceeded)
            {
                _logger.LogError($"Deserialization Error: {responseBody}");
                return new ResponseViewModel<IEnumerable<ProductModel>>
                {
                    IsSucceeded = false,
                    Errors = new List<ErrorViewModel>
            {
                new ErrorViewModel { Message = "Deserialization error" }
            }
                };
            }

            return result;
        }
      public async  Task<ResponseViewModel<IEnumerable<ProductModel>>> GetRelatedProductsAsync(int productId)
        {
            var client = GetHttpClient();
            var response = await client.GetAsync($"products/getrelatedproducts/{productId}");
            var responseBody = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode || string.IsNullOrEmpty(responseBody))
            {
                return new ResponseViewModel<IEnumerable<ProductModel>>
                {
                    IsSucceeded = false,
                    Errors = new List<ErrorViewModel>
                {
                    new ErrorViewModel { Message = "İlgili ürünler getirilirken bir hata oluştu." }
                }
                };
            }

            var result = JsonSerializer.Deserialize<ResponseViewModel<IEnumerable<ProductModel>>>(responseBody, _jsonSerializerOptions);

            return result ?? new ResponseViewModel<IEnumerable<ProductModel>>
            {
                IsSucceeded = false,
                Errors = new List<ErrorViewModel> { new ErrorViewModel { Message = "API'den geçerli veri alınamadı." } }
            };
        }
    }
}
