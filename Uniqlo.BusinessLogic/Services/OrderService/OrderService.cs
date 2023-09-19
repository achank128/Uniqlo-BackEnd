using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
        private readonly IProductDetailRepository _productDetailRepository;

        public OrderService(
            IMapper mapper,
            IOrderRepository orderRepository,
            IRepositoryBase<OrderItem> orderItemRepository,
            IPaymentRepository paymentRepository,
            IShipmentRepository shipmentRepository,
            IProductDetailRepository productDetailRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
            _paymentRepository = paymentRepository;
            _shipmentRepository = shipmentRepository;
            _productDetailRepository = productDetailRepository;
        }


        public async Task<ApiResponse<OrderResponse>> Create(CreateOrderRequest request)
        {
            var order = _mapper.Map<Order>(request);
            _orderRepository.Add(order);
            if (await _orderRepository.SaveAsync())
            {
                var response = _mapper.Map<OrderResponse>(order);
                return ApiResponse<OrderResponse>.Success(OrderKeywords.CreateSuccess, response);
            }
            else
            {
                throw new BadRequestException(OrderKeywords.CreateFailure);
            }
        }

        public async Task<ApiResponse<OrderResponse>> CreateFull(CreateOrderFullRequest request)
        {
            var order = _mapper.Map<Order>(request);
            order.Id = Guid.NewGuid();
            _orderRepository.Add(order);

            if (request.OrderItems.Count() <= 0)
            {
                throw new BadRequestException(OrderKeywords.OrderItemEmpty);
            }

            foreach (var item in request.OrderItems)
            {
                var productDetail = await _productDetailRepository.GetByIdAsync(item.ProductDetailId);
                if (productDetail.InStock < item.Quantity)
                {
                    throw new BadRequestException(OrderKeywords.OrderProductOutOfStock);
                }
                productDetail.InStock -= item.Quantity;
                productDetail.Sold += item.Quantity;
                _productDetailRepository.Update(productDetail);
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
            _shipmentRepository.Add(shipment);

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
            _paymentRepository.Add(payment);

            if (await _orderRepository.SaveAsync())
            {
                var response = _mapper.Map<OrderResponse>(order);
                return ApiResponse<OrderResponse>.Success(OrderKeywords.CreateSuccess, response);
            }
            else
            {
                throw new BadRequestException(OrderKeywords.CreateFailure);
            }
        }

        public async Task<ApiResponse<OrderResponse>> Delete(Guid id, DeleteRequest request)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null) throw new NotFoundException(Common.NotFound);
            order.DeleteStatus = request.DeleteStatus;
            if (await _orderRepository.SaveAsync())
            {
                return ApiResponse<OrderResponse>.Success(OrderKeywords.DeleteSuccess);
            }
            else
            {
                throw new BadRequestException(OrderKeywords.DeleteFailure);
            }
        }

        public async Task<PagedResponse<OrderResponse>> Filter(FilterOrderRequest request)
        {
            var orders = _orderRepository.FilterOrders(request);
            var ordersOpen = await orders.Where(o => o.Status == "OPEN").CountAsync();
            var ordersConfirmed = await orders.Where(o => o.Status == "CONFIRMED").CountAsync();
            var ordersCompleted = await orders.Where(o => o.Status == "COMPLETED").CountAsync();
            var ordersCancelled = await orders.Where(o => o.Status == "CANCELLED").CountAsync();

            var statistics = new {
                ordersOpen,
                ordersConfirmed,
                ordersCompleted,
                ordersCancelled
            };

            var paged = await PagedResponse<Order>.CreateStatisticAsync(orders, request.PageIndex, request.PageSize, statistics);
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
            var order = await _orderRepository.GetOrderById(id);
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

        public async Task<ApiResponse<OrderResponse>> Update(UpdateOrderRequest request)
        {
            var order = _mapper.Map<Order>(request);
            order.UpdatedDate = DateTime.Now;
            _orderRepository.Update(order);
            if (await _orderRepository.SaveAsync())
            {
                return ApiResponse<OrderResponse>.Success(OrderKeywords.UpdateSuccess);
            }
            else
            {
                throw new BadRequestException(OrderKeywords.UpdateFailure);
            }
        }

        public async Task<ApiResponse<OrderResponse>> UpdateStatus(UpdateOrderStatusRequest request)
        {
            var order = await _orderRepository.GetByIdAsync(request.Id);
            if (order == null) throw new NotFoundException(Common.NotFound);

            if(request.Status == "CANCELLED")
            {
                if (order.Status != "OPEN")
                {
                    throw new BadRequestException(OrderKeywords.OrderCannotCancel);
                }
                var orderItems = await _orderItemRepository.GetBy(o => o.OrderId == order.Id).ToListAsync();
                foreach (var item in orderItems)
                {
                    var productDetail = await _productDetailRepository.GetByIdAsync(item.ProductDetailId);
                    if (productDetail.InStock < item.Quantity)
                    {
                        throw new BadRequestException(OrderKeywords.OrderProductOutOfStock);
                    }
                    productDetail.InStock += item.Quantity;
                    productDetail.Sold -= item.Quantity;
                    _productDetailRepository.Update(productDetail);
                }
                order.Status = "CANCELLED";
                order.CancelReason = request.Reason;
            } 
            else
            {
                order.Status = request.Status;
            }
            order.UpdatedDate = DateTime.Now;
            _orderRepository.Update(order);
            if (await _orderRepository.SaveAsync())
            {
                return ApiResponse<OrderResponse>.Success(OrderKeywords.UpdateSuccess);
            }
            else
            {
                throw new BadRequestException(OrderKeywords.UpdateFailure);
            }
        }
    }
}
