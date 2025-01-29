using AutoMapper;
using AutoMapper.Configuration.Annotations;
using ECommerce.Business.Abstract;
using ECommerce.Data.Abstract;
using ECommerce.Entity.Concrete;
using ECommerce.Shared.ComplexTypes;
using ECommerce.Shared.DTOs.CategoryDTOs;
using ECommerce.Shared.DTOs.ProductDTOs;
using ECommerce.Shared.DTOs.ResponseDTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IImageService _imageService;


        public ProductService(IUnitOfWork unitOfWork, IMapper mapper, IImageService imageService)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            _imageService = imageService;
        }

        public async Task<ResponseDTO<ProductDTO>> AddProductAsync(ProductCreateDTO productCreateDTO)
        {
            var category = await unitOfWork.GetRepository<Category>().GetByIdAsync(productCreateDTO.CategoryId);
            if (category == null)
            {
                return ResponseDTO<ProductDTO>.Fail(new List<ErrorDetail>
            {
                new ErrorDetail{
                Message=$"Category not found with id={productCreateDTO.CategoryId}",
                Code="CategoryNotFound",
                Target=nameof(productCreateDTO.CategoryId)

                }
            }, HttpStatusCode.NotFound);

            }
            if (productCreateDTO.SubcategoryId.HasValue)
            {
                var subcategory = await unitOfWork.GetRepository<Category>().GetByIdAsync(productCreateDTO.SubcategoryId.Value);
                if (subcategory == null)
                {
                    return ResponseDTO<ProductDTO>.Fail(new List<ErrorDetail>
                    {
                        new ErrorDetail {

                            Message = $"Subcategory not found with id: {productCreateDTO.SubcategoryId}",
                            Code = "SubcategoryNotFound",
                            Target = nameof(productCreateDTO.SubcategoryId)
                        }
                    }, HttpStatusCode.NotFound);

                }
            }
            var newProduct = mapper.Map<Product>(productCreateDTO);
            if (productCreateDTO.Image != null)
            {
                var imageUrl = await _imageService.UploadImageAsync(productCreateDTO.Image);
                newProduct.ImageUrl = imageUrl;
            }

            newProduct.IsActive = true;
            newProduct.CreatedAt = DateTime.Now;

            await unitOfWork.GetRepository<Product>().AddAsync(newProduct);
            await unitOfWork.SaveChangesAsync();
            var productDTO = mapper.Map<ProductDTO>(newProduct);
            return ResponseDTO<ProductDTO>.Success(productDTO, HttpStatusCode.Created);

        }

        public async Task<ResponseDTO<IEnumerable<ProductDTO>>> GetAllProductsAsync(int? take = null)
        {
            var producs = await unitOfWork.GetRepository<Product>().GetAllAsync(null, orderBy: query => query.OrderByDescending(x => x.CreatedAt),
                take: take);
            if (producs == null || !producs.Any())
            {
                return ResponseDTO<IEnumerable<ProductDTO>>.Fail(new List<ErrorDetail>
                {
                    new ErrorDetail {
                        Message = "No product found",
                        Code = "ProductNotFound",
                        Target = nameof(producs)
                    }
                }, HttpStatusCode.NotFound);


            }
            var productDTOs = mapper.Map<IEnumerable<ProductDTO>>(producs);
            return ResponseDTO<IEnumerable<ProductDTO>>.Success(productDTOs, HttpStatusCode.OK);

        }

        public async Task<ResponseDTO<int>> GetCountBySubCategory(int subCategoryId)
        {
            var categoryIsAny = await unitOfWork.GetRepository<Product>().AnyAsync(x => x.SubcategoryId == subCategoryId);
            if (!categoryIsAny)
            {
                return ResponseDTO<int>.Fail(new List<ErrorDetail>
                {
                    new ErrorDetail {
                        Message = "No product found",
                        Code = "ProductNotFound",
                        Target = nameof(categoryIsAny)
                    }
                }, HttpStatusCode.NotFound);
            }
            var count = unitOfWork.GetRepository<Product>().CountAsync(x => x.SubcategoryId == subCategoryId);
            return ResponseDTO<int>.Success(count.Result, HttpStatusCode.OK);
        }

        public async Task<ResponseDTO<ProductDTO>> GetProductByIdAsync(int id)
        {
            var product = await unitOfWork.GetRepository<Product>().GetByIdAsync(id);
            if (product == null)
            {
                return ResponseDTO<ProductDTO>.Fail(new List<ErrorDetail>
                {
                    new ErrorDetail {
                        Message = "Product not found",
                        Code = "ProductNotFound",
                        Target = nameof(product)
                    }
                }, HttpStatusCode.NotFound);
            }
            var productDTO = mapper.Map<ProductDTO>(product);
            return ResponseDTO<ProductDTO>.Success(productDTO, HttpStatusCode.OK);
        }

        public async Task<ResponseDTO<int>> GetProductCountAsync(bool? isActive)
        {
            var ActiveorInActiveProductCount = unitOfWork.GetRepository<Product>().CountAsync(x => x.IsActive == isActive);


            if (ActiveorInActiveProductCount.Result == 0)
            {
                return ResponseDTO<int>.Fail(new List<ErrorDetail>
                {
                    new ErrorDetail {
                        Message = "Products not found",
                        Code = "Products not found",
                        Target = nameof(ActiveorInActiveProductCount)
                    }
                }, HttpStatusCode.NotFound);
            }


            return ResponseDTO<int>.Success(ActiveorInActiveProductCount.Result, HttpStatusCode.OK);


        }





        public async Task<ResponseDTO<IEnumerable<ProductDTO>>> GetProductsWithCategoriesAsync(int parentCategoryId)
        {
            var products = await unitOfWork.GetRepository<Product>().GetAllAsync(x => x.CategoryId == parentCategoryId);
            if (products == null || !products.Any())
            {
                return ResponseDTO<IEnumerable<ProductDTO>>.Fail(new List<ErrorDetail>
                {
                    new ErrorDetail {
                        Message = "No product found",
                        Code = "ProductNotFound",
                        Target = nameof(products)
                    }
                }, HttpStatusCode.NotFound);
            }
            var productDTOs = mapper.Map<IEnumerable<ProductDTO>>(products);
            return ResponseDTO<IEnumerable<ProductDTO>>.Success(productDTOs, HttpStatusCode.OK);

        }


        public async Task<ResponseDTO<IEnumerable<ProductDTO>>> GetProductsBySubCategoryIdAsync(int subCategoryId)
        {
            var products = await unitOfWork.GetRepository<Product>().GetAllAsync(x => x.SubcategoryId == subCategoryId);
            if (products == null || !products.Any())
            {
                return ResponseDTO<IEnumerable<ProductDTO>>.Fail(new List<ErrorDetail>
                {
                    new ErrorDetail {
                        Message = "No product found",
                        Code = "ProductNotFound",
                        Target = nameof(products)
                    }
                }, HttpStatusCode.NotFound);

            }
            var productDTOs = mapper.Map<IEnumerable<ProductDTO>>(products);
            return ResponseDTO<IEnumerable<ProductDTO>>.Success(productDTOs, HttpStatusCode.OK);
        }

        public async Task<ResponseDTO<NoContent>> HardDeleteProductAsync(int id)
        {
            var product = await unitOfWork.GetRepository<Product>().GetByIdAsync(id);

            if (product == null)
            {
                return ResponseDTO<NoContent>.Fail(new List<ErrorDetail>
        {
            new ErrorDetail
            {
                Message = "Product not found",
                Code = "ProductNotFound",
                Target = nameof(id)
            }
        }, HttpStatusCode.NotFound);
            }


            if (product.IsDeleted)
            {
                unitOfWork.GetRepository<Product>().HardDeleteAsync(p => p.Id == product.Id);
                await unitOfWork.SaveChangesAsync();
                return ResponseDTO<NoContent>.Success(HttpStatusCode.OK);
            }


            return ResponseDTO<NoContent>.Fail(new List<ErrorDetail>
    {
        new ErrorDetail
        {
            Message = "The product is not marked as deleted. Cannot perform hard delete.",
            Code = "CannotHardDelete",
            Target = nameof(id)
        }
    }, HttpStatusCode.BadRequest);
        }








        public async Task<ResponseDTO<NoContent>> SoftDeleteProductAsync(int id)
        {
            var product = await unitOfWork.GetRepository<Product>().GetByIdAsync(id);
            if (product == null)
            {
                return ResponseDTO<NoContent>.Fail(new List<ErrorDetail>
                {
                    new ErrorDetail{
                        Message = "Product not found",
                        Code = "ProductNotFound",
                        Target = nameof(id)
                    }

                   }, HttpStatusCode.NotFound);

            }
            if (product.IsDeleted)
            {
                return ResponseDTO<NoContent>.Fail(new List<ErrorDetail>
                {
                    new ErrorDetail{
                        Message = "Product already marked as deleted",
                        Code = "ProductAlreadyDeleted",
                        Target = nameof(id)
                    }
                }, HttpStatusCode.BadRequest);
            }
            product.IsDeleted = true;
            unitOfWork.GetRepository<Product>().UpdateAsync(product);
            await unitOfWork.SaveChangesAsync();
            return ResponseDTO<NoContent>.Success(HttpStatusCode.OK);
        }

        public async Task<ResponseDTO<NoContent>> UpdateProductAsync(ProductUpdateDTO productUpdateDTO)
        {

            var product = await unitOfWork.GetRepository<Product>().GetByIdAsync(productUpdateDTO.Id);


            if (product == null)
            {
                return ResponseDTO<NoContent>.Fail(new List<ErrorDetail>
        {
            new ErrorDetail
            {
                Message = "Product not found",
                Code = "ProductNotFound",
                Target = nameof(productUpdateDTO.Id)
            }
        }, HttpStatusCode.NotFound);
            }


            if (!product.IsActive)
            {
                return ResponseDTO<NoContent>.Fail(new List<ErrorDetail>
        {
            new ErrorDetail
            {
                Message = "The product is not active. Cannot update.",
                Code = "ProductNotActive",
                Target = nameof(productUpdateDTO.Id)
            }
        }, HttpStatusCode.BadRequest);
            }


            if (product.IsDeleted)
            {
                return ResponseDTO<NoContent>.Fail(new List<ErrorDetail>
        {
            new ErrorDetail
            {
                Message = "The product is marked as deleted. Cannot update.",
                Code = "ProductDeleted",
                Target = nameof(productUpdateDTO.Id)
            }
        }, HttpStatusCode.BadRequest);
            }

            mapper.Map(productUpdateDTO, product);
            product.UpdatedAt = DateTime.UtcNow;

            unitOfWork.GetRepository<Product>().UpdateAsync(product);
            await unitOfWork.SaveChangesAsync();

            return ResponseDTO<NoContent>.Success(HttpStatusCode.OK);
        }

      

        public async Task<ResponseDTO<IEnumerable<ProductDTO>>> FilterProducts(int? productSize, int? productColor, decimal? minPrice, decimal? maxPrice)
        {
           
            var query = await unitOfWork.GetRepository<Product>().QueryAsync();

           
            if (productSize.HasValue)
            {
                var size = (ProductSize)productSize.Value;
                query = query.Where(x => x.Size == size);
            }

           
            if (productColor.HasValue)
            {
                var color = (ProductColor)productColor.Value;
                query = query.Where(x => x.Color == color);
            }

           
            if (minPrice.HasValue && maxPrice.HasValue)
            {
                query = query.Where(x => x.UnitPrice >= minPrice.Value && x.UnitPrice <= maxPrice.Value);
            }
            else if (minPrice.HasValue)
            {
                query = query.Where(x => x.UnitPrice >= minPrice.Value);
            }
            else if (maxPrice.HasValue)
            {
                query = query.Where(x => x.UnitPrice <= maxPrice.Value);
            }

     
            var products = await query.ToListAsync();

       
            if (products == null || !products.Any())
            {
                return ResponseDTO<IEnumerable<ProductDTO>>.Fail(new List<ErrorDetail>
        {
            new ErrorDetail
            {
                Message = "No products found with the specified filters",
                Code = "ProductNotFound",
                Target = "Filters"
            }
        }, HttpStatusCode.NotFound);
            }

     
            var productDTOs = mapper.Map<IEnumerable<ProductDTO>>(products);

            return ResponseDTO<IEnumerable<ProductDTO>>.Success(productDTOs, HttpStatusCode.OK);
        }

    }
}