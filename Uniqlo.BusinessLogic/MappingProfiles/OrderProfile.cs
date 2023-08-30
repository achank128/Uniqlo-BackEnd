using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.Models.EntityModels;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels.Order;
using Uniqlo.Models.RequestModels.Payment;
using Uniqlo.Models.ResponseModels;

namespace Uniqlo.BusinessLogic.MappingProfiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<CreateOrderRequest, Order>();
            CreateMap<CreateOrderFullRequest, Order>();
            CreateMap<UpdateOrderRequest, Order>();
            CreateMap<Order, OrderResponse>();
            CreateMap<PagedResponse<Order>, PagedResponse<OrderResponse>>();
        }
    }
}
