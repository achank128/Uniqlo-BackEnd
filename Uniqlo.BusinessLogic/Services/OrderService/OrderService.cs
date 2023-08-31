using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.BusinessLogic.Exceptions;
using Uniqlo.Core.Enums;
using Uniqlo.Core.Keywords;
using Uniqlo.DataAccess.Repositories.Interfaces;
using Uniqlo.DataAccess.RepositoryBase;
using Uniqlo.Models.EntityModels;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels;
using Uniqlo.Models.RequestModels.Order;
using Uniqlo.Models.ResponseModels;

namespace Uniqlo.BusinessLogic.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;
        private readonly IRepositoryBase<OrderItem> _orderItemRepository;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IShipmentRepository _shipmentRepository;

        public OrderService(
            IMapper mapper,
            IOrderRepository orderRepository,
            IRepositoryBase<OrderItem> orderItemRepository,
            IPaymentRepository paymentRepository,
            IShipmentRepository shipmentRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
            _paymentRepository = paymentRepository;
            _shipmentRepository = shipmentRepository;
        }

        public async Task<ApiResponse<OrderResponse>> Cancel(CancelOrderRequest request)
        {
            
            var order = await _orderRepository.GetByIdAsync(request.Id);
            if (order == null) throw new NotFoundException(Common.NotFound);

            if(order.Status == "COMPLETED")
            {
                throw new BadRequestException(OrderKeywords.OrderCompleted);
            }
            if (order.Status == "CONFIRMED" )
            {
                throw new BadRequestException(OrderKeywords.OrderCompleted);
            }

            order.Status = "CANCELED";
            order.CancelReason = request.CancelReason;

            _orderRepository.Update(order);
            if (await _orderRepository.SaveAsync())
            {
                return ApiResponse<OrderResponse>.Success(Common.UpdateSuccess);
            }
            else
            {
                throw new BadRequestException(Common.UpdateFailure);
            }
        }

        public async Task<ApiResponse<OrderResponse>> Create(CreateOrderRequest request)
        {
            var order = _mapper.Map<Order>(request);
            _orderRepository.Add(order);
            if (await _orderRepository.SaveAsync())
            {
                var response = _mapper.Map<OrderResponse>(order);
                return ApiResponse<OrderResponse>.Success(Common.CreateSuccess, response);
            }
            else
            {
                throw new BadRequestException(Common.CreateFailure);
            }
        }

        public async Task<ApiResponse<OrderResponse>> CreateFull(CreateOrderFullRequest request)
        {
            var order = _mapper.Map<Order>(request);
            order.Id = Guid.NewGuid();

            List<OrderItem> orderItems = new List<OrderItem>();
            foreach (var item in request.OrderItems)
            {
                OrderItem orderItem = new OrderItem
                {
                    Id = Guid.NewGuid(),
                    OrderId = order.Id,
                    ProductDetailId = item.ProductDetailId,
                    Quantity = item.Quantity,
                    Price = item.Price
                };
                orderItems.Add(orderItem);
            }

            Shipment shipment = new Shipment
            {
                Id = Guid.NewGuid(),
                OrderId = order.Id,
                UserAddressId = request.UserAddressId,
                ReceivedDate = request.ReceivedDate,
                Amount = request.Amount,
                ShipmentPay = request.ShipmentPay,
                Note = request.Note,
            };

            Payment payment = new Payment
            {
                Id = Guid.NewGuid(),
                OrderId = order.Id,
                PaymentType = request.PaymentType,
                PaymentDate = request.PaymentDate,
                CreditCardName = request.CreditCardName,
                CreditCardDate = request.CreditCardDate,
                CreditCardType = request.CreditCardType,
                CreditCardNumber = request.CreditCardNumber,
                CreditCardNumberDisplay = request.CreditCardNumberDisplay,
                Note = request.PaymentNote
            };

            _orderRepository.Add(order);
            _orderItemRepository.AddRange(orderItems);
            _paymentRepository.Add(payment);
            _shipmentRepository.Add(shipment);

            if (await _orderRepository.SaveAsync())
            {
                var response = _mapper.Map<OrderResponse>(order);
                return ApiResponse<OrderResponse>.Success(Common.CreateSuccess, response);
            }
            else
            {
                throw new BadRequestException(Common.CreateFailure);
            }
        }

        public async Task<ApiResponse<OrderResponse>> Delete(Guid id, DeleteRequest request)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null) throw new NotFoundException(Common.NotFound);
            order.DeleteStatus = request.DeleteStatus;
            if (await _orderRepository.SaveAsync())
            {
                return ApiResponse<OrderResponse>.Success(Common.DeleteSuccess);
            }
            else
            {
                throw new BadRequestException(Common.DeleteFailure);
            }
        }

        public async Task<PagedResponse<OrderResponse>> Filter(FilterOrderRequest request)
        {
            var orders = _orderRepository.GetQueryable();
            var paged = await PagedResponse<Order>.CreateAsync(orders, request.PageIndex, request.PageSize);
            var response = _mapper.Map<PagedResponse<OrderResponse>>(paged);
            return response;
        }
        public async Task<ApiResponse<List<OrderResponse>>> GetAll()
        {
            var alls = await _orderRepository.GetAllAsync();
            var response = _mapper.Map<List<OrderResponse>>(alls);
            return ApiResponse<List<OrderResponse>>.Success(response);
        }

        public async Task<ApiResponse<OrderResponse>> GetById(Guid id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null) throw new NotFoundException(Common.NotFound);
            var response = _mapper.Map<OrderResponse>(order);
            return ApiResponse<OrderResponse>.Success(response);
        }

        public async Task<ApiResponse<List<OrderResponse>>> GetOrderByUser(Guid userId)
        {
            var order = await _orderRepository.GetOrderByUser(userId);
            if (order == null) throw new NotFoundException(Common.NotFound);
            var response = _mapper.Map<List<OrderResponse>>(order);
            return ApiResponse<List<OrderResponse>>.Success(response);
        }

        public async Task<ApiResponse<OrderResponse>> GetOrderDetails(Guid id)
        {
            var order = await _orderRepository.GetOrderById(id);
            if (order == null) throw new NotFoundException(Common.NotFound);
            var response = _mapper.Map<OrderResponse>(order);
            return ApiResponse<OrderResponse>.Success(response);
        }

        public async Task<ApiResponse<OrderResponse>> Update(UpdateOrderRequest request)
        {
            var order = _mapper.Map<Order>(request);
            order.UpdatedDate = DateTime.Now;
            _orderRepository.Update(order);
            if (await _orderRepository.SaveAsync())
            {
                return ApiResponse<OrderResponse>.Success(Common.UpdateSuccess);
            }
            else
            {
                throw new BadRequestException(Common.UpdateFailure);
            }
        }
    }
}
