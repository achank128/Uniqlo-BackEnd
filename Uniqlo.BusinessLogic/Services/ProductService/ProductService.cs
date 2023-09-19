using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.BusinessLogic.Exceptions;
using Uniqlo.Core.Keywords;
using Uniqlo.DataAccess.Repositories.Implements;
using Uniqlo.DataAccess.Repositories.Interfaces;
using Uniqlo.DataAccess.RepositoryBase;
using Uniqlo.Models.EntityModels;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels;
using Uniqlo.Models.RequestModels.Product;
using Uniqlo.Models.ResponseModels;

namespace Uniqlo.BusinessLogic.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly IProductDetailRepository _productDetailRepository;
        private readonly IRepositoryBase<ProductReview> _productReviewRepository;
        private readonly IRepositoryBase<ProductPrice> _productPriceRepository;
        private readonly IRepositoryBase<ProductCategory> _productCategoryRepository;
        private readonly IRepositoryBase<ProductSize> _productSizeRepository;
        private readonly IRepositoryBase<ProductColor> _productColorRepository;
        private readonly IRepositoryBase<ProductImage> _productImageRepository;

        public ProductService(
            IMapper mapper,
            IProductRepository productRepository,
            IProductDetailRepository productDetailRepository,
            IRepositoryBase<ProductReview> productReviewRepository,
            IRepositoryBase<ProductPrice> productPriceRepository,
            IRepositoryBase<ProductCategory> productCategoryRepository,
            IRepositoryBase<ProductSize> productSizeRepository,
            IRepositoryBase<ProductColor> productColorRepository,
            IRepositoryBase<ProductImage> productImageRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _productReviewRepository = productReviewRepository;
            _productDetailRepository = productDetailRepository;
            _productPriceRepository = productPriceRepository;
            _productCategoryRepository = productCategoryRepository;
            _productSizeRepository = productSizeRepository;
            _productColorRepository = productColorRepository;
            _productImageRepository = productImageRepository;
        }

        public async Task<ApiResponse<ProductResponse>> Create(CreateProductRequest request)
        {
            var product = _mapper.Map<Product>(request);
            product.Id = Guid.NewGuid();

            //Add product review
            ProductReview productReview = new ProductReview
            {
                Id = Guid.NewGuid(),
                Star = 0,
                Amount = 0,
            };
            _productReviewRepository.Add(productReview);
            product.ProductReviewId = productReview.Id;

            //Add product price
            ProductPrice productPrice = new ProductPrice
            {
                Id = Guid.NewGuid(),
                Price = request.Price,
                PromoPrice = request.PromoPrice,
                ImportPrice = request.ImportPrice,
                VAT = request.VAT,
            };
            _productPriceRepository.Add(productPrice);
            product.ProductPriceId = productPrice.Id;

            _productRepository.Add(product);

            if (await _productRepository.SaveAsync())
            {
                return ApiResponse<ProductResponse>.Success(Common.CreateSuccess);
            }
            else
            {
                throw new BadRequestException(Common.CreateFailure);
            }
        }

        public async Task<ApiResponse<ProductResponse>> CreateCrawl(CreateProductCrawlRequest request)
        {
            var product = _mapper.Map<Product>(request);
            product.Id = Guid.NewGuid();
            _productRepository.CreateCrawl(product, request);

            if (await _productRepository.SaveAsync())
            {
                return ApiResponse<ProductResponse>.Success(Common.CreateSuccess);
            }
            else
            {
                throw new BadRequestException(Common.CreateFailure);
            }
        }

        public async Task<ApiResponse<ProductResponse>> CreateFull(CreateProductFullRequest request)
        {
            var product = _mapper.Map<Product>(request);
            product.Id = Guid.NewGuid();

            //Add product review
            ProductReview productReview = new ProductReview
            {
                Id = Guid.NewGuid(),
                Star = 0,
                Amount = 0,
            };
            _productReviewRepository.Add(productReview);
            product.ProductReviewId = productReview.Id;

            //Add product price
            ProductPrice productPrice = new ProductPrice
            {
                Id = Guid.NewGuid(),
                Price = request.Price,
                PromoPrice = request.PromoPrice,
                ImportPrice = request.ImportPrice,
                VAT = request.VAT,  
            };
            _productPriceRepository.Add(productPrice);
            product.ProductPriceId = productPrice.Id;

            //Add product categories
            foreach (Guid categoryId in request.Categories)
            {
                ProductCategory productCategory = new ProductCategory { 
                    Id = Guid.NewGuid(), 
                    CategoryId = categoryId,
                    ProductId = product.Id,
                };
                _productCategoryRepository.Add(productCategory);
            }

            //Add product sizes
            foreach (int sizeId in request.Sizes)
            {
                ProductSize productSize = new ProductSize
                {
                    Id = Guid.NewGuid(),
                    SizeId = sizeId,
                    ProductId = product.Id,
                };
                _productSizeRepository.Add(productSize);
            }

            //Add product colors
            foreach (int colorId in request.Colors)
            {
                ProductColor productColor = new ProductColor
                {
                    Id = Guid.NewGuid(),
                    ColorId = colorId,
                    ProductId = product.Id,
                };
                _productColorRepository.Add(productColor);
            }

            //Add product details
            foreach (int colorId in request.Colors)
            {
                foreach (int sizeId in request.Sizes)
                {

                    ProductDetail productDetail = new ProductDetail
                    {
                        Id = Guid.NewGuid(),
                        SizeId = sizeId,
                        ColorId = colorId,
                        ProductId = product.Id,
                        InStock = 0,
                    };
                    _productDetailRepository.Add(productDetail);
                }
            }

            _productRepository.Add(product);

            if (await _productRepository.SaveAsync())
            {
                var response = _mapper.Map<ProductResponse>(product);
                return ApiResponse<ProductResponse>.Success(Common.CreateSuccess, response);
            }
            else
            {
                throw new BadRequestException(Common.CreateFailure);
            }
        }

        public async Task<ApiResponse<ProductResponse>> Delete(Guid id, DeleteRequest request)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null) throw new NotFoundException(Common.NotFound);
            product.DeleteStatus = request.DeleteStatus;
            if (await _productRepository.SaveAsync())
            {
                return ApiResponse<ProductResponse>.Success(Common.DeleteSuccess);
            }
            else
            {
                throw new BadRequestException(Common.DeleteFailure);
            }
        }

        public async Task<PagedResponse<ProductResponse>> Filter(FilterProductRequest request)
        {
            var products = _productRepository.FilterProducts(request);

            if (!string.IsNullOrEmpty(request.SortBy))
            {
                products = _productRepository.SortProducts(products, request.SortBy);
            }

            var paged = await PagedResponse<Product>.CreateAsync(products, request.PageIndex, request.PageSize);
            var response = _mapper.Map<PagedResponse<ProductResponse>>(paged);
            return response;
        }

        public async Task<ApiResponse<List<ProductResponse>>> GetAll()
        {
            var alls = await _productRepository.GetAllAsync();
            var response = _mapper.Map<List<ProductResponse>>(alls);
            return ApiResponse<List<ProductResponse>>.Success(response);
        }

        public async Task<ApiResponse<ProductResponse>> GetById(Guid id)
        {
            var product = await _productRepository.GetProductById(id);
            if (product == null) throw new NotFoundException(Common.NotFound);

            var response = _mapper.Map<ProductResponse>(product);
            return ApiResponse<ProductResponse>.Success(response);
        }

        public async Task<ApiResponse<ProductResponse>> Update(UpdateProductRequest request)
        {
            var category = _mapper.Map<Product>(request);
            category.UpdatedDate = DateTime.Now;
            _productRepository.Update(category);
            if (await _productRepository.SaveAsync())
            {
                return ApiResponse<ProductResponse>.Success(Common.UpdateSuccess);
            }
            else
            {
                throw new BadRequestException(Common.UpdateFailure);
            }
        }

        public async Task<ApiResponse<ProductResponse>> UpdateFull(UpdateProductFullRequest request)
        {
            var product = _mapper.Map<Product>(request);

            //Update product price
            var productPrice = await _productPriceRepository.GetByIdAsync(product.ProductPriceId);
            productPrice.Price = request.Price;
            productPrice.PromoPrice = request.PromoPrice;
            productPrice.ImportPrice = request.ImportPrice;
            productPrice.VAT = request.VAT;
            _productPriceRepository.Update(productPrice);

            //Update product categories
            var productCategories = await _productCategoryRepository.GetBy(c => c.ProductId == product.Id).ToListAsync();
            _productCategoryRepository.DeleteRange(productCategories);
            foreach (Guid categoryId in request.Categories)
            {
                ProductCategory productCategory = new ProductCategory
                {
                    Id = Guid.NewGuid(),
                    CategoryId = categoryId,
                    ProductId = product.Id,
                };
                _productCategoryRepository.Add(productCategory);
            }

            //Update product images
            if(request.ProductImagesUpdate != null)
            {
                var productImages = await _productImageRepository.GetBy(i => i.ProductId == product.Id).ToListAsync();
                _productImageRepository.DeleteRange(productImages);
                foreach (var item in request.ProductImagesUpdate)
                {
                    ProductImage productImage = new ProductImage
                    {
                        Id = Guid.NewGuid(),
                        ProductId = item.ProductId,
                        Image = item.Image,
                        ImageUrl = item.ImageUrl,
                        Type = item.Type,
                    };
                    _productImageRepository.Add(productImage);
                }
            }

            ////Add product sizes
            //foreach (int sizeId in request.Sizes)
            //{
            //    ProductSize productSize = new ProductSize
            //    {
            //        Id = Guid.NewGuid(),
            //        SizeId = sizeId,
            //        ProductId = product.Id,
            //    };
            //    _productSizeRepository.Add(productSize);
            //}

            ////Add product colors
            //foreach (int colorId in request.Colors)
            //{
            //    ProductColor productColor = new ProductColor
            //    {
            //        Id = Guid.NewGuid(),
            //        ColorId = colorId,
            //        ProductId = product.Id,
            //    };
            //    _productColorRepository.Add(productColor);
            //}

            ////Add product details
            //foreach (int colorId in request.Colors)
            //{
            //    foreach (int sizeId in request.Sizes)
            //    {

            //        ProductDetail productDetail = new ProductDetail
            //        {
            //            Id = Guid.NewGuid(),
            //            SizeId = sizeId,
            //            ColorId = colorId,
            //            ProductId = product.Id,
            //            InStock = 0,
            //        };
            //        _productDetailRepository.Add(productDetail);
            //    }
            //}



            _productRepository.Update(product);

            if (await _productRepository.SaveAsync())
            {
                var response = _mapper.Map<ProductResponse>(product);
                return ApiResponse<ProductResponse>.Success(Common.UpdateSuccess, response);
            }
            else
            {
                throw new BadRequestException(Common.UpdateFailure);
            }
        }
    }
}
