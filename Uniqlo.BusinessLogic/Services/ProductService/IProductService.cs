using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels;
using Uniqlo.Models.RequestModels.Product;
using Uniqlo.Models.ResponseModels;

namespace Uniqlo.BusinessLogic.Services.ProductService
{
    public interface IProductService
    {
        Task<ApiResponse<ProductResponse>> Create(CreateProductRequest request);
        Task<ApiResponse<ProductResponse>> CreateFull(CreateProductFullRequest request);
        Task<ApiResponse<ProductResponse>> CreateCrawl(CreateProductCrawlRequest request);
        Task<PagedResponse<ProductResponse>> Filter(FilterProductRequest request);
        Task<ApiResponse<List<ProductResponse>>> GetAll();
        Task<ApiResponse<ProductResponse>> GetById(Guid id);
        Task<ApiResponse<ProductResponse>> Update(UpdateProductRequest request);
        Task<ApiResponse<ProductResponse>> Delete(Guid id, DeleteRequest request);
    }
}
