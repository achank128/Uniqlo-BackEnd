using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.Models.EntityModels;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels.UserAddress;
using Uniqlo.Models.ResponseModels;

namespace Uniqlo.BusinessLogic.MappingProfiles
{
    public class UserAddressProfile : Profile
    {
        public UserAddressProfile()
        {
            CreateMap<CreateUserAddressRequest, UserAddress>();
            CreateMap<UpdateUserAddressRequest, UserAddress>();
            CreateMap<UserAddress, UserAddressResponse>();
            CreateMap<PagedResponse<UserAddress>, PagedResponse<UserAddressResponse>>();
        }
    }
}
