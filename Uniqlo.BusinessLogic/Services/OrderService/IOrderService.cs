﻿using System;
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
        Task<PagedResponse<OrderResponse>> GetAll(FilterBaseRequest request);
        Task<ApiResponse<OrderResponse>> GetById(Guid id);
        Task<ApiResponse<OrderResponse>> GetOrderDetails(Guid id);
        Task<ApiResponse<OrderResponse>> Update(UpdateOrderRequest request);
        Task<ApiResponse<OrderResponse>> Cancel(CancelOrderRequest request);
        Task<ApiResponse<OrderResponse>> Delete(Guid id, DeleteRequest request);
    }
}