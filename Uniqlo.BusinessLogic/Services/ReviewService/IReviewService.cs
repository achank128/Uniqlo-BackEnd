using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels.Review;
using Uniqlo.Models.ResponseModels;

namespace Uniqlo.BusinessLogic.Services.ReviewService
{
    public interface IReviewService
    {
        Task<ApiResponse<ReviewResponse>> Create(CreateReviewRequest request);
        Task<PagedResponse<ReviewResponse>> Filter(FilterReviewRequest request);
        Task<ApiResponse<List<ReviewResponse>>> GetAll();
        Task<ApiResponse<List<ReviewResponse>>> GetByUser(Guid userId);
        Task<ApiResponse<ReviewResponse>> GetById(Guid id);
        Task<ApiResponse<ReviewResponse>> Update(UpdateReviewRequest request);
        Task<ApiResponse<ReviewResponse>> Delete(Guid id);
    }
}
