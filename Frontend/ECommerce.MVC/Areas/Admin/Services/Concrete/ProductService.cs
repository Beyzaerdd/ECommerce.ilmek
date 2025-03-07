using ECommerce.MVC.Areas.Admin.Models.ProductModels;
using ECommerce.MVC.Areas.Admin.Services.Abstract;
using ECommerce.MVC.Models.ProductModels;
using ECommerce.MVC.Views.Shared.ResponseViewModels;
using System.Text;
using System.Text.Json;

namespace ECommerce.MVC.Areas.Admin.Services.Concrete
{
    public class ProductService:MVC.Services.Abstract.BaseService, IProductService

    {
        private readonly MVC.Services.Abstract.IEnumService enumService;
        public ProductService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor, MVC.Services.Abstract.IEnumService enumService) : base(httpClientFactory, httpContextAccessor)
        {
            this.enumService = enumService;
        }

        public async Task<ResponseViewModel<ProductModel>> AddProductAsync(ProductCreateModel productCreateModel)
        {
            try
            {
                var client = GetHttpClient();

                using var content = new MultipartFormDataContent();

               
                content.Add(new StringContent(productCreateModel.Name), nameof(productCreateModel.Name));
                content.Add(new StringContent(productCreateModel.UnitPrice.ToString()), nameof(productCreateModel.UnitPrice));
                content.Add(new StringContent(productCreateModel.Description), nameof(productCreateModel.Description));
                content.Add(new StringContent(productCreateModel.PreparationTimeInDays.ToString()), nameof(productCreateModel.PreparationTimeInDays));
                content.Add(new StringContent(productCreateModel.IsActive.ToString()), nameof(productCreateModel.IsActive));
                content.Add(new StringContent(productCreateModel.CategoryId.ToString()), nameof(productCreateModel.CategoryId));
                content.Add(new StringContent(productCreateModel.Stock.ToString()), nameof(productCreateModel.Stock));


                foreach (var size in productCreateModel.AvailableSizeIds)
                {
                    content.Add(new StringContent(size.ToString()), nameof(productCreateModel.AvailableSizes));
                }

                foreach (var color in productCreateModel.AvailableColorIds)
                {
                    content.Add(new StringContent(color.ToString()), nameof(productCreateModel.AvailableColors));
                }


                if (productCreateModel.Image != null)
                {
                    var fileStream = productCreateModel.Image.OpenReadStream();
                    var fileContent = new StreamContent(fileStream);
                    content.Add(fileContent, "Image", productCreateModel.Image.FileName);


                    content.Add(new StringContent(""), nameof(productCreateModel.ImageUrl));
                }
                else if (!string.IsNullOrEmpty(productCreateModel.ImageUrl))
                {

                    content.Add(new StringContent(productCreateModel.ImageUrl), nameof(productCreateModel.ImageUrl));
                }
                else
                {

                    content.Add(new StringContent(""), nameof(productCreateModel.ImageUrl));
                }

               
                var response = await client.PostAsync("Products/AddProduct", content);

            
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
                var response = await client.GetAsync($"products/getBySeller?applicationUserId={applicationUserId}");


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

            content.Add(new StringContent(productUpdateModel.Id.ToString()), nameof(productUpdateModel.Id));
            content.Add(new StringContent(productUpdateModel.Name), nameof(productUpdateModel.Name));
            content.Add(new StringContent(productUpdateModel.UnitPrice.ToString()), nameof(productUpdateModel.UnitPrice));
            content.Add(new StringContent(productUpdateModel.Description), nameof(productUpdateModel.Description));
            content.Add(new StringContent(productUpdateModel.PreparationTimeInDays.ToString()), nameof(productUpdateModel.PreparationTimeInDays));
            content.Add(new StringContent(productUpdateModel.IsActive.ToString()), nameof(productUpdateModel.IsActive));
            content.Add(new StringContent(productUpdateModel.CategoryId.ToString()), nameof(productUpdateModel.CategoryId));
            content.Add(new StringContent(productUpdateModel.Stock.ToString()), nameof(productUpdateModel.Stock));
         

            foreach (var size in productUpdateModel.AvailableSizeIds)
            {
                content.Add(new StringContent(size.ToString()), nameof(productUpdateModel.AvailableSizes));
            }

            foreach (var color in productUpdateModel.AvailableColorIds)
            {
                content.Add(new StringContent(color.ToString()), nameof(productUpdateModel.AvailableColors));
            }


            if (productUpdateModel.Image != null)
            {
                var fileStream = productUpdateModel.Image.OpenReadStream();
                var fileContent = new StreamContent(fileStream);
                content.Add(fileContent, "Image", productUpdateModel.Image.FileName);

           
                content.Add(new StringContent(""), nameof(productUpdateModel.ImageUrl));
            }
            else if (!string.IsNullOrEmpty(productUpdateModel.ImageUrl))
            {
     
                content.Add(new StringContent(productUpdateModel.ImageUrl), nameof(productUpdateModel.ImageUrl));
            }
            else
            {
        
                content.Add(new StringContent(""), nameof(productUpdateModel.ImageUrl));
            }
            var response = await client.PutAsync("products", content);
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
