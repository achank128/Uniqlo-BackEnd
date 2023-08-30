using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels.ProductDetail;
using Uniqlo.Models.ResponseModels;

namespace Uniqlo.BusinessLogic.Services.ProductDetailService
{
    public interface IProductDetailService
    {
        Task<ApiResponse<ProductDetailResponse>> Create(CreateProductDetailRequest request);
        Task<ApiResponse<ProductDetailResponse>> CreateList(CreateListProductDetailRequest request);
        Task<PagedResponse<ProductDetailResponse>> Filter(FilterBaseRequest request);
        Task<ApiResponse<List<ProductDetailResponse>>> GetAll();
        Task<ApiResponse<ProductDetailResponse>> GetById(Guid id);
        Task<ApiResponse<ProductDetailResponse>> Update(UpdateProductDetailRequest request);
        Task<ApiResponse<ProductDetailResponse>> Delete(Guid id);
    }
}
