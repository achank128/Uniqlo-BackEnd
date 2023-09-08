using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels.Coupon;
using Uniqlo.Models.ResponseModels;

namespace Uniqlo.BusinessLogic.Services.CouponService
{
    public interface ICouponService
    {
        Task<ApiResponse<CouponResponse>> Create(CreateCouponRequest request);
        Task<PagedResponse<CouponResponse>> Filter(FilterBaseRequest request);
        Task<ApiResponse<List<CouponResponse>>> GetAll();
        Task<ApiResponse<List<CouponResponse>>> GetByUser(Guid userId);
        Task<ApiResponse<CouponResponse>> GetById(Guid id);
        Task<ApiResponse<CouponResponse>> Update(UpdateCouponRequest request);
        Task<ApiResponse<CouponResponse>> Delete(Guid id);
        
    }
}
