using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.BusinessLogic.Exceptions;
using Uniqlo.Core.Keywords;
using Uniqlo.DataAccess.Repositories.Interfaces;
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

        public ProductDetailService(IProductDetailRepository productDetailRepository, IMapper mapper)
        {
            _productDetailRepository = productDetailRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<ProductDetailResponse>> Create(CreateProductDetailRequest request)
        {
            var category = _mapper.Map<ProductDetail>(request);
            _productDetailRepository.Add(category);

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
            var category = await _productDetailRepository.GetByIdAsync(id);
            if (category == null) throw new NotFoundException(Common.NotFound);

            _productDetailRepository.DeleteBy(id);
            if (await _productDetailRepository.SaveAsync())
            {
                return ApiResponse<ProductDetailResponse>.Success(Common.DeleteSuccess);
            }
            else
            {
                throw new BadRequestException(Common.DeleteFailure);
            }
        }

        public async Task<PagedResponse<ProductDetailResponse>> GetAll(FilterBaseRequest request)
        {
            var categories = _productDetailRepository.GetQueryable();
            var paged = await PagedResponse<ProductDetail>.CreateAsync(categories, request.PageIndex, request.PageSize);
            var response = _mapper.Map<PagedResponse<ProductDetailResponse>>(paged);
            return response;
        }

        public async Task<ApiResponse<ProductDetailResponse>> GetById(Guid id)
        {
            var category = await _productDetailRepository.GetByIdAsync(id);
            if (category == null) throw new NotFoundException(Common.NotFound);

            var response = _mapper.Map<ProductDetailResponse>(category);
            return ApiResponse<ProductDetailResponse>.Success(response);
        }

        public async Task<ApiResponse<ProductDetailResponse>> Update(UpdateProductDetailRequest request)
        {
            var category = _mapper.Map<ProductDetail>(request);
            category.UpdatedDate = DateTime.Now;
            _productDetailRepository.Update(category);
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
