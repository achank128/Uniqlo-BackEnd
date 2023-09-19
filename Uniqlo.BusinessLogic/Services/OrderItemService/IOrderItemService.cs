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
    public interface IOrderItemService
    {
        Task<ApiResponse<OrderItemResponse>> Create(CreateOrderItemRequest request);
        Task<PagedResponse<OrderItemResponse>> Filter(FilterBaseRequest request);
        Task<ApiResponse<List<OrderItemResponse>>> GetAll();
        Task<ApiResponse<OrderItemResponse>> GetById(Guid id);
        Task<ApiResponse<List<OrderItemResponse>>> GetByOrder(Guid orderId);
        Task<ApiResponse<OrderItemResponse>> Delete(Guid id);
    }
}
