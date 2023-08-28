using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.Models.EntityModels;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels.Coupon;
using Uniqlo.Models.ResponseModels;

namespace Uniqlo.BusinessLogic.MappingProfiles
{
    public class CouponProfile : Profile
    {
        public CouponProfile()
        {
            CreateMap<CreateCouponRequest, Coupon>();
            CreateMap<UpdateCouponRequest, Coupon>();
            CreateMap<Coupon, CouponResponse>();
            CreateMap<PagedResponse<Coupon>, PagedResponse<CouponResponse>>();

            CreateMap<CreateUserCouponRequest, UserCoupon>();
            CreateMap<UserCoupon, UserCouponResponse>();

        }
    }
}
