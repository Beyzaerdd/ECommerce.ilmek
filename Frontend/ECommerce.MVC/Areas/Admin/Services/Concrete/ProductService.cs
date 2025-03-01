using ECommerce.MVC.Areas.Admin.Models.ProductModels;
using ECommerce.MVC.Areas.Admin.Services.Abstract;
using ECommerce.MVC.Models.ProductModels;
using ECommerce.MVC.Views.Shared.ResponseViewModels;
using System.Text.Json;

namespace ECommerce.MVC.Areas.Admin.Services.Concrete
{
    public class ProductService:MVC.Services.Abstract.BaseService, IProductService

    {
        public ProductService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor) : base(httpClientFactory, httpContextAccessor) { }

        public async Task<ResponseViewModel<ProductModel>> AddProductAsync(ProductCreateModel productCreateModel)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.PostAsJsonAsync("Products/AddProduct", productCreateModel);

                if (!response.IsSuccessStatusCode)
                {
                    return new ResponseViewModel<ProductModel>
                    {
                        IsSucceeded = false,
                        Errors = new List<ErrorViewModel>
                {
                    new ErrorViewModel { Message = "Ürün eklenirken bir hata oluştu. Hata kodu: " + response.StatusCode }
                }
                    };
                }

                var responseBody = await response.Content.ReadAsStringAsync();
                if (string.IsNullOrEmpty(responseBody))
                {
                    return new ResponseViewModel<ProductModel>
                    {
                        IsSucceeded = false,
                        Errors = new List<ErrorViewModel> { new ErrorViewModel { Message = "API'den geçerli veri alınamadı." } }
                    };
                }

                var result = JsonSerializer.Deserialize<ResponseViewModel<ProductModel>>(responseBody, _jsonSerializerOptions);

                return result ?? new ResponseViewModel<ProductModel>
                {
                    IsSucceeded = false,
                    Errors = new List<ErrorViewModel> { new ErrorViewModel { Message = "Veri deserialize edilemedi." } }
                };
            }
            catch (Exception ex)
            {
                return new ResponseViewModel<ProductModel>
                {
                    IsSucceeded = false,
                    Errors = new List<ErrorViewModel>
            {
                new ErrorViewModel { Message = "Bir hata oluştu: " + ex.Message }
            }
                };
            }
        }

        public async  Task<ResponseViewModel<IEnumerable<ProductModel>>> GetAllProductsAsync(int? take = null)
        {

            var client = GetHttpClient();
            var response = await client.GetAsync($"products/getall?take=null");
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

        public async  Task<ResponseViewModel<ProductModel>> GetProductByIdAsync(int id)
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

        public async Task<ResponseViewModel<IEnumerable<ProductModel>>> GetProductBySellerAsync(string applicationUserId, int? take = null)
        {
            try
            {
                var client = GetHttpClient();
                var response = await client.GetAsync($"products/getBySeller?applicationUserId={applicationUserId}&take=null");

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

        public async Task<ResponseViewModel<int>> GetProductCountAsync(bool? isActive)
        {
            var client = GetHttpClient();
            var response = await client.GetAsync($"products/getCount?isActive?-={isActive}");
            var responseBody = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode || string.IsNullOrEmpty(responseBody))
            {
                return new ResponseViewModel<int>
                {
                    IsSucceeded = false,
                    Errors = new List<ErrorViewModel>
                {
                    new ErrorViewModel { Message = "Ürün Sayısı alınırken hata oluştu." }
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

        public async Task<ResponseViewModel<NoContentViewModel>> HardDeleteProductAsync(int id)
        {
            var client = GetHttpClient();
            var response = await client.DeleteAsync($"products/hardDelete/{id}");
            var responseBody = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode || string.IsNullOrEmpty(responseBody))
            {
                return new ResponseViewModel<NoContentViewModel>
                {
                    IsSucceeded = false,
                    Errors = new List<ErrorViewModel>
                {
                    new ErrorViewModel { Message = "Ürün silinirken alınırken hata oluştu." }
                }
                };
            }

            var result = JsonSerializer.Deserialize<ResponseViewModel<NoContentViewModel>>(responseBody, _jsonSerializerOptions);

            return result ?? new ResponseViewModel<NoContentViewModel>
            {
                IsSucceeded = false,
                Errors = new List<ErrorViewModel> { new ErrorViewModel { Message = "API'den geçerli veri alınamadı." } }
            };
        }

    

        public async Task<ResponseViewModel<NoContentViewModel>> SoftDeleteProductAsync(int id)
        {
            var client = GetHttpClient();
            var response = await client.DeleteAsync($"products/softDelete/{id}");
            var responseBody = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode || string.IsNullOrEmpty(responseBody))
            {
                return new ResponseViewModel<NoContentViewModel>
                {
                    IsSucceeded = false,
                    Errors = new List<ErrorViewModel>
                {
                    new ErrorViewModel { Message = "Ürün silinirken alınırken hata oluştu." }
                }
                };
            }

            var result = JsonSerializer.Deserialize<ResponseViewModel<NoContentViewModel>>(responseBody, _jsonSerializerOptions);

            return result ?? new ResponseViewModel<NoContentViewModel>
            {
                IsSucceeded = false,
                Errors = new List<ErrorViewModel> { new ErrorViewModel { Message = "API'den geçerli veri alınamadı." } }
            };
        }

        public async Task<ResponseViewModel<NoContentViewModel>> UpdateProductAsync(ProductUpdateModel productUpdateModel)
        {
            var client = GetHttpClient();

            using var content = new MultipartFormDataContent();

            content.Add(new StringContent(productUpdateModel.Id.ToString()),productUpdateModel.Id.ToString());
            content.Add(new StringContent(productUpdateModel.Name), productUpdateModel.Name);
            content.Add(new StringContent(productUpdateModel.UnitPrice.ToString()), productUpdateModel.UnitPrice.ToString());
            content.Add(new StringContent(productUpdateModel.Description), productUpdateModel.Description.ToString());
            content.Add(new StringContent(productUpdateModel.PreparationTimeInDays.ToString()), productUpdateModel.PreparationTimeInDays.ToString());
            content.Add(new StringContent(productUpdateModel.IsActive.ToString()), productUpdateModel.IsActive.ToString());
            content.Add(new StringContent(productUpdateModel.CategoryId.ToString()), productUpdateModel.CategoryId.ToString());
            content.Add(new StringContent(productUpdateModel.AvailableColors.ToString()), productUpdateModel.AvailableColors.ToString());
            content.Add(new StringContent(productUpdateModel.AvailableSizes.ToString()), productUpdateModel.AvailableSizes.ToString());
            content.Add(new StringContent(productUpdateModel.Stock.ToString()), productUpdateModel.Stock.ToString());


            if (productUpdateModel.Image != null)
            {
                var fileStream = productUpdateModel.Image.OpenReadStream();
                var fileContent = new StreamContent(fileStream);
                content.Add(fileContent, "Image", productUpdateModel.Image.FileName);
            }

            var response = await client.PutAsync($"api/products/update/{productUpdateModel.Id}", content);
            var responseBody = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode || string.IsNullOrEmpty(responseBody))
            {
                return new ResponseViewModel<NoContentViewModel>
                {
                    IsSucceeded = false,
                    Errors = new List<ErrorViewModel>
            {
                new ErrorViewModel { Message = "Ürün güncellenirken hata oluştu." }
            }
                };
            }

            var result = JsonSerializer.Deserialize<ResponseViewModel<NoContentViewModel>>(responseBody, _jsonSerializerOptions);

            return result ?? new ResponseViewModel<NoContentViewModel>
            {
                IsSucceeded = false,
                Errors = new List<ErrorViewModel> { new ErrorViewModel { Message = "API'den geçerli veri alınamadı." } }
            };
        }

    }
}
