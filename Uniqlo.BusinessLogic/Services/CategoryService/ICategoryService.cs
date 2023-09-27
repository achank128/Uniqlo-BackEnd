using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels.Category;
using Uniqlo.Models.ResponseModels;

namespace Uniqlo.BusinessLogic.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<ApiResponse<CategoryResponse>> Create(CreateCategoryRequest request);
        Task<PagedResponse<CategoryResponse>> Filter(FilterBaseRequest request);
        Task<ApiResponse<List<CategoryResponse>>> GetAll();
        Task<ApiResponse<List<CategoryResponse>>> GetDisplayByGendeType(int genderTypeId);
        Task<ApiResponse<List<CategoryResponse>>> GetByProduct(Guid productId);
        Task<ApiResponse<CategoryResponse>> GetById(Guid id);
        Task<ApiResponse<CategoryResponse>> Update(UpdateCategoryRequest request);
        Task<ApiResponse<CategoryResponse>> Delete(Guid id);
    }
}
