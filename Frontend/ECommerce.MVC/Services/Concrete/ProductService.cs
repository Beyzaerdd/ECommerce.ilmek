using ECommerce.MVC.Models.ProductModels;
using ECommerce.MVC.Services.Abstract;
using ECommerce.MVC.Views.Shared.ResponseViewModels;
using ECommerce.Shared.ComplexTypes;
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

        public async Task<ResponseViewModel<IEnumerable<ProductColor>>> GetAvailableColorsAsync()
        {
            var client = GetHttpClient();  

            try
            {
               
                var response = await client.GetAsync("products/colors");

               
                if (!response.IsSuccessStatusCode)
                {
                    return new ResponseViewModel<IEnumerable<ProductColor>>
                    {
                        IsSucceeded = false,
                        Errors = new List<ErrorViewModel>
                    {
                        new ErrorViewModel { Message = "Renkler getirilirken bir hata oluştu." }
                    }
                    };
                }

          
                var responseBody = await response.Content.ReadAsStringAsync();

           
                if (string.IsNullOrEmpty(responseBody))
                {
                    return new ResponseViewModel<IEnumerable<ProductColor>>
                    {
                        IsSucceeded = false,
                        Errors = new List<ErrorViewModel>
                    {
                        new ErrorViewModel { Message = "API'den geçerli renk verisi alınamadı." }
                    }
                    };
                }

      
                var colors = JsonSerializer.Deserialize<IEnumerable<ProductColor>>(responseBody);

       
                if (colors == null)
                {
                    return new ResponseViewModel<IEnumerable<ProductColor>>
                    {
                        IsSucceeded = false,
                        Errors = new List<ErrorViewModel>
                    {
                        new ErrorViewModel { Message = "Renk verileri işlenemedi." }
                    }
                    };
                }

         
                return new ResponseViewModel<IEnumerable<ProductColor>>
                {
                    IsSucceeded = true,
                    Data = colors
                };
            }
            catch (Exception ex)
            {
               
                return new ResponseViewModel<IEnumerable<ProductColor>>
                {
                    IsSucceeded = false,
                    Errors = new List<ErrorViewModel>
                {
                    new ErrorViewModel { Message = $"Beklenmedik bir hata oluştu: {ex.Message}" }
                }
                };
            }
        }

      
        public async Task<ResponseViewModel<IEnumerable<ProductSize>>> GetAvailableSizesAsync()
        {
            var client = GetHttpClient();  

            try
            {
            
                var response = await client.GetAsync("products/sizes");

              
                if (!response.IsSuccessStatusCode)
                {
                    return new ResponseViewModel<IEnumerable<ProductSize>>
                    {
                        IsSucceeded = false,
                        Errors = new List<ErrorViewModel>
                    {
                        new ErrorViewModel { Message = "Bedenler getirilirken bir hata oluştu." }
                    }
                    };
                }

            
                var responseBody = await response.Content.ReadAsStringAsync();

             
                if (string.IsNullOrEmpty(responseBody))
                {
                    return new ResponseViewModel<IEnumerable<ProductSize>>
                    {
                        IsSucceeded = false,
                        Errors = new List<ErrorViewModel>
                    {
                        new ErrorViewModel { Message = "API'den geçerli beden verisi alınamadı." }
                    }
                    };
                }

       
                var sizes = JsonSerializer.Deserialize<IEnumerable<ProductSize>>(responseBody);

             
                if (sizes == null)
                {
                    return new ResponseViewModel<IEnumerable<ProductSize>>
                    {
                        IsSucceeded = false,
                        Errors = new List<ErrorViewModel>
                    {
                        new ErrorViewModel { Message = "Beden verileri işlenemedi." }
                    }
                    };
                }

            
                return new ResponseViewModel<IEnumerable<ProductSize>>
                {
                    IsSucceeded = true,
                    Data = sizes
                };
            }
            catch (Exception ex)
            {
            
                return new ResponseViewModel<IEnumerable<ProductSize>>
                {
                    IsSucceeded = false,
                    Errors = new List<ErrorViewModel>
                {
                    new ErrorViewModel { Message = $"Beklenmedik bir hata oluştu: {ex.Message}" }
                }
                };
            }
        }
    






    public async Task<ResponseViewModel<IEnumerable<ProductModel>>> GetAllProductAsync()
        {
            var client = GetHttpClient();
            var response = await client.GetAsync("products/GetAll");
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
            var response = await client.GetAsync($"products/GetProductById?id={id}");
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

            var url = $"products/filterProducts?categoryId={categoryId}";

            if (selectedSizes != null && selectedSizes.Any())
            {
                url += string.Join("&", selectedSizes.Select(size => $"productSizes={size}"));
            }

            if (selectedColors != null && selectedColors.Any())
            {
                url += string.Join("&", selectedColors.Select(color => $"productColors={color}"));
            }


            if (minPrice.HasValue)
            {
                url += $"&minPrice={minPrice.Value}";
            }

            if (maxPrice.HasValue)
            {
                url += $"&maxPrice={maxPrice.Value}";
            }

            _logger.LogInformation($"API Request: {client.BaseAddress}{url}"); 

            var response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                _logger.LogError($"API Error: {response.StatusCode} - {errorContent}"); 

                return new ResponseViewModel<IEnumerable<ProductModel>>
                {
                    IsSucceeded = false,
                    Errors = new List<ErrorViewModel> { new ErrorViewModel { Message = $"API Error: {response.StatusCode} - {errorContent}" } }
                };
            }

            var responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<ResponseViewModel<IEnumerable<ProductModel>>>(responseBody, _jsonSerializerOptions); 

            if (result == null || !result.IsSucceeded)
            {
                _logger.LogError($"Deserialization Error: {responseBody}"); 
                return new ResponseViewModel<IEnumerable<ProductModel>>
                {
                    IsSucceeded = false,
                    Errors = new List<ErrorViewModel> { new ErrorViewModel { Message = "Deserialization error" } }
                };
            }

            return result;
        }


    }
}
