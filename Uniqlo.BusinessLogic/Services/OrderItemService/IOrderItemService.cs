using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels.Category;
using Uniqlo.Models.RequestModels.OrderItem;
using Uniqlo.Models.ResponseModels;

namespace Uniqlo.BusinessLogic.Services.OderItemService
{
    public interface IOrderItemService
    {
        Task<ApiResponse<OrderItemResponse>> Create(CreateOrderItemRequest request);
        Task<ApiResponse<OrderItemResponse>> GetById(Guid id);
        Task<ApiResponse<OrderItemResponse>> Delete(Guid id);
    }
}
