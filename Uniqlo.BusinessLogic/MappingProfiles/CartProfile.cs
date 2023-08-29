using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.Models.EntityModels;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels.Cart;
using Uniqlo.Models.ResponseModels;

namespace Uniqlo.BusinessLogic.MappingProfiles
{
    public class CartProfile : Profile
    {
        public CartProfile()
        {
            CreateMap<CreateCartRequest, Cart>();
            CreateMap<UpdateCartRequest, Cart>();
            CreateMap<Cart, CartResponse>();
            CreateMap<PagedResponse<Cart>, PagedResponse<CartResponse>>();
        }
    }
}
