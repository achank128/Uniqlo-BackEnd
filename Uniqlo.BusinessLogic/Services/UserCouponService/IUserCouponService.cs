using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels.Coupon;
using Uniqlo.Models.ResponseModels;

namespace Uniqlo.BusinessLogic.Services.UserCouponService
{
    public interface IUserCouponService
    {
        Task<ApiResponse<UserCouponResponse>> CreateUserCoupon(CreateUserCouponRequest request);
        Task<ApiResponse<UserCouponResponse>> AddUserCoupon(Guid userId, Guid couponId);
        Task<PagedResponse<UserCouponResponse>> Filter(FilterBaseRequest request);
        Task<ApiResponse<List<UserCouponResponse>>> GetAll();
        Task<ApiResponse<List<UserCouponResponse>>> GetUserCoupons(Guid userId);
        Task<ApiResponse<UserCouponResponse>> DeleteUserCoupon(Guid id);
    }
}
