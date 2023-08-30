using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.BusinessLogic.Exceptions;
using Uniqlo.Core.Keywords;
using Uniqlo.DataAccess.Repositories.Implements;
using Uniqlo.DataAccess.Repositories.Interfaces;
using Uniqlo.DataAccess.RepositoryBase;
using Uniqlo.Models.EntityModels;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels.ProductDetail;
using Uniqlo.Models.ResponseModels;

namespace Uniqlo.BusinessLogic.Services.ProductDetailService
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly IMapper _mapper;
        private readonly IProductDetailRepository _productDetailRepository;
        private readonly IRepositoryBase<ProductSize> _productSizeRepository;

        public ProductDetailService(
            IMapper mapper, 
            IProductDetailRepository productDetailRepository, 
            IRepositoryBase<ProductSize> productSizeRepository)
        {
            _productDetailRepository = productDetailRepository;
            _mapper = mapper;
            _productSizeRepository = productSizeRepository;
        }

        public async Task<ApiResponse<ProductDetailResponse>> Create(CreateProductDetailRequest request)
        {
            var productDetail = _mapper.Map<ProductDetail>(request);
            _productDetailRepository.Add(productDetail);

            if (await _productDetailRepository.SaveAsync())
            {
                return ApiResponse<ProductDetailResponse>.Success(Common.CreateSuccess);
            }
            else
            {
                throw new BadRequestException(Common.CreateFailure);
            }
        }

        public async Task<ApiResponse<ProductDetailResponse>> CreateList(CreateListProductDetailRequest request)
        {
            //Add product sizes
            foreach (int sizeId in request.Sizes)
            {
                ProductSize productSize = new ProductSize
                {
                    Id = Guid.NewGuid(),
                    SizeId = sizeId,
                    ProductId = request.ProductId,
                };
                _productSizeRepository.Add(productSize);
            }

            List<ProductDetail> productDetails = new List<ProductDetail>();

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
                        ProductId = request.ProductId,
                        InStock = request.InStock,
                        StockStatus = request.InStock > 0
                    };
                    productDetails.Add(productDetail);
                }
            }

            _productDetailRepository.AddRange(productDetails);
            if (await _productDetailRepository.SaveAsync())
            {
                return ApiResponse<ProductDetailResponse>.Success(Common.CreateSuccess);
            }
            else
            {
                throw new BadRequestException(Common.CreateFailure);
            }
        }

        public async Task<ApiResponse<ProductDetailResponse>> Delete(Guid id)
        {
            var productDetail = await _productDetailRepository.GetByIdAsync(id);
            if (productDetail == null) throw new NotFoundException(Common.NotFound);

            productDetail.DeleteStatus = true;
            _productDetailRepository.Update(productDetail);
            if (await _productDetailRepository.SaveAsync())
            {
                return ApiResponse<ProductDetailResponse>.Success(Common.DeleteSuccess);
            }
            else
            {
                throw new BadRequestException(Common.DeleteFailure);
            }
        }

        public async Task<PagedResponse<ProductDetailResponse>> Filter(FilterBaseRequest request)
        {
            var productDetails = _productDetailRepository.GetQueryable();
            var paged = await PagedResponse<ProductDetail>.CreateAsync(productDetails, request.PageIndex, request.PageSize);
            var response = _mapper.Map<PagedResponse<ProductDetailResponse>>(paged);
            return response;
        }

        public async Task<ApiResponse<List<ProductDetailResponse>>> GetAll()
        {
            var alls = await _productDetailRepository.GetAllAsync();
            var response = _mapper.Map<List<ProductDetailResponse>>(alls);
            return ApiResponse<List<ProductDetailResponse>>.Success(response);
        }

        public async Task<ApiResponse<ProductDetailResponse>> GetById(Guid id)
        {
            var productDetail = await _productDetailRepository.GetByIdAsync(id);
            if (productDetail == null) throw new NotFoundException(Common.NotFound);

            var response = _mapper.Map<ProductDetailResponse>(productDetail);
            return ApiResponse<ProductDetailResponse>.Success(response);
        }

        public async Task<ApiResponse<ProductDetailResponse>> Update(UpdateProductDetailRequest request)
        {
            var productDetail = _mapper.Map<ProductDetail>(request);
            productDetail.UpdatedDate = DateTime.Now;
            _productDetailRepository.Update(productDetail);
            if (await _productDetailRepository.SaveAsync())
            {
                return ApiResponse<ProductDetailResponse>.Success(Common.UpdateSuccess);
            }
            else
            {
                throw new BadRequestException(Common.UpdateFailure);
            }
        }
    }
}
