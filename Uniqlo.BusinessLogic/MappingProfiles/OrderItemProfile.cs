using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.Models.EntityModels;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels.OrderItem;
using Uniqlo.Models.ResponseModels;

namespace Uniqlo.BusinessLogic.MappingProfiles
{
    public class OrderItemProfile : Profile
    {
        public OrderItemProfile()
        {
            CreateMap<CreateOrderItemRequest, OrderItem>();
            CreateMap<OrderItem, OrderItemResponse>();
            CreateMap<PagedResponse<OrderItem>, PagedResponse<OrderItemResponse>>();
        }
    }
}
