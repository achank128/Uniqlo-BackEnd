using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.Models.EntityModels;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels.CartItem;
using Uniqlo.Models.ResponseModels;

namespace Uniqlo.BusinessLogic.MappingProfiles
{
    public class CartItemProfile : Profile
    {
        public CartItemProfile()
        {
            CreateMap<CreateCartItemRequest, CartItem>();
            CreateMap<UpdateCartItemRequest, CartItem>();
            CreateMap<CartItem, CartItemResponse>();
            CreateMap<PagedResponse<CartItem>, PagedResponse<CartItemResponse>>();
        }
    }
}
