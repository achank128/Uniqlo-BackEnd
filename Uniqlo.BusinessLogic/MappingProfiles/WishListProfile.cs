using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.Models.EntityModels;
using Uniqlo.Models.Models;
using Uniqlo.Models.ResponseModels;

namespace Uniqlo.BusinessLogic.MappingProfiles
{
    public class WishListProfile : Profile
    {
        public WishListProfile()
        {
            CreateMap<WishList, WishListResponse>();
            CreateMap<PagedResponse<WishList>, PagedResponse<WishListResponse>>();
        }
    }
}
