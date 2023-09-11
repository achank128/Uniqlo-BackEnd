using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels;
using Uniqlo.Models.ResponseModels;
using Uniqlo.Models.RequestModels.Order;

namespace Uniqlo.BusinessLogic.Services.OrderService
{
    public interface IOrderService
    {
        Task<ApiResponse<OrderResponse>> Create(CreateOrderRequest request);
        Task<ApiResponse<OrderResponse>> CreateFull(CreateOrderFullRequest request);
        Task<PagedResponse<OrderResponse>> Filter(FilterOrderRequest request);
        Task<ApiResponse<List<OrderResponse>>> GetAll();
        Task<ApiResponse<List<OrderResponse>>> GetOrderByUser(Guid userId);
        Task<ApiResponse<OrderResponse>> GetById(Guid id);
        Task<ApiResponse<OrderResponse>> GetOrderDetails(Guid id);
        Task<ApiResponse<OrderResponse>> Update(UpdateOrderRequest request);
        Task<ApiResponse<OrderResponse>> UpdateStatus(UpdateOrderStatusRequest request);
        Task<ApiResponse<OrderResponse>> Delete(Guid id, DeleteRequest request);
    }
}
