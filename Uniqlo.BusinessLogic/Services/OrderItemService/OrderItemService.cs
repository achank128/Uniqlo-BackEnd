using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels.OrderItem;
using Uniqlo.Models.ResponseModels;

namespace Uniqlo.BusinessLogic.Services.OderItemService
{
    public class OrderItemService : IOrderItemService
    {
        public Task<ApiResponse<OrderItemResponse>> Create(CreateOrderItemRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<OrderItemResponse>> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<OrderItemResponse>> GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
