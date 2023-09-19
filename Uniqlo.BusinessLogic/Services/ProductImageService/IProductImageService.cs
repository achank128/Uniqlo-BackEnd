using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels.Color;
using Uniqlo.Models.RequestModels.ProductImage;
using Uniqlo.Models.ResponseModels;

namespace Uniqlo.BusinessLogic.Services.ProductImageService
{
    public interface IProductImageService
    {
        Task<ApiResponse<ProductImageResponse>> Create(CreateProductImageRequest request);
        Task<ApiResponse<List<ProductImageResponse>>> Uploads(UploadProductImageRequest request);
        Task<PagedResponse<ProductImageResponse>> Filter(FilterBaseRequest request);
        Task<ApiResponse<List<ProductImageResponse>>> GetAll();
        Task<ApiResponse<ProductImageResponse>> GetById(Guid id);
        Task<ApiResponse<ProductImageResponse>> Update(UpdateProductImageRequest request);
        Task<ApiResponse<ProductImageResponse>> Delete(Guid id);
    }
}
