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
    public class UserCouponProfile : Profile
    {
        public UserCouponProfile()
        {
            CreateMap<CreateUserCouponRequest, UserCoupon>();
            CreateMap<UserCoupon, UserCouponResponse>();
            CreateMap<PagedResponse<UserCoupon>, PagedResponse<UserCouponResponse>>();
        }
    }
}
