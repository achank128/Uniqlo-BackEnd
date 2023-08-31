using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.BusinessLogic.Exceptions;
using Uniqlo.Core.Keywords;
using Uniqlo.DataAccess.Repositories.Interfaces;
using Uniqlo.Models.EntityModels;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels.OrderItem;
using Uniqlo.Models.ResponseModels;

namespace Uniqlo.BusinessLogic.Services.OderItemService
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IMapper _mapper;
        private readonly IOrderItemRepository _orderItemRepository;

        public OrderItemService(IOrderItemRepository orderItemRepository, IMapper mapper)
        {
            _orderItemRepository = orderItemRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<OrderItemResponse>> Create(CreateOrderItemRequest request)
        {
            var orderItem = _mapper.Map<OrderItem>(request);
            _orderItemRepository.Add(orderItem);

            if (await _orderItemRepository.SaveAsync())
            {
                return ApiResponse<OrderItemResponse>.Success(Common.CreateSuccess);
            }
            else
            {
                throw new BadRequestException(Common.CreateFailure);
            }
        }

        public async Task<ApiResponse<OrderItemResponse>> Delete(Guid id)
        {
            var orderItem = await _orderItemRepository.GetByIdAsync(id);
            if (orderItem == null) throw new NotFoundException(Common.NotFound);

            _orderItemRepository.Delete(orderItem);
            if (await _orderItemRepository.SaveAsync())
            {
                return ApiResponse<OrderItemResponse>.Success(Common.DeleteSuccess);
            }
            else
            {
                throw new BadRequestException(Common.DeleteFailure);
            }
        }

        public async Task<PagedResponse<OrderItemResponse>> Filter(FilterBaseRequest request)
        {
            var orderItems = _orderItemRepository.GetQueryable();
            var paged = await PagedResponse<OrderItem>.CreateAsync(orderItems, request.PageIndex, request.PageSize);
            var response = _mapper.Map<PagedResponse<OrderItemResponse>>(paged);
            return response;
        }

        public async Task<ApiResponse<List<OrderItemResponse>>> GetAll()
        {
            var alls = await _orderItemRepository.GetAllAsync();
            var response = _mapper.Map<List<OrderItemResponse>>(alls);
            return ApiResponse<List<OrderItemResponse>>.Success(response);
        }

        public async Task<ApiResponse<OrderItemResponse>> GetById(Guid id)
        {
            var orderItem = await _orderItemRepository.GetOrderItemById(id);
            if (orderItem == null) throw new NotFoundException(Common.NotFound);

            var response = _mapper.Map<OrderItemResponse>(orderItem);
            return ApiResponse<OrderItemResponse>.Success(response);
        }

        public async Task<ApiResponse<List<OrderItemResponse>>> GetByOrder(Guid orderId)
        {
            var orderItems = await _orderItemRepository.GetOrderItemByOrder(orderId);
            var response = _mapper.Map<List<OrderItemResponse>> (orderItems);
            return ApiResponse<List<OrderItemResponse>>.Success(response);
        }
    }
}
