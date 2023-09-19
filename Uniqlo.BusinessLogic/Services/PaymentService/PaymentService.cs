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
using Uniqlo.Models.RequestModels.Payment;
using Uniqlo.Models.ResponseModels;

namespace Uniqlo.BusinessLogic.Services.PaymentService
{
    public class PaymentService : IPaymentService
    {
        private readonly IMapper _mapper;
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<PaymentResponse>> Create(CreatePaymentRequest request)
        {
            var payment = _mapper.Map<Payment>(request);
            _paymentRepository.Add(payment);

            if (await _paymentRepository.SaveAsync())
            {
                return ApiResponse<PaymentResponse>.Success(Common.CreateSuccess);
            }
            else
            {
                throw new BadRequestException(Common.CreateFailure);
            }
        }

        public async Task<ApiResponse<PaymentResponse>> Delete(Guid id)
        {
            var payment = await _paymentRepository.GetByIdAsync(id);
            if (payment == null) throw new NotFoundException(Common.NotFound);

            _paymentRepository.Delete(payment);
            if (await _paymentRepository.SaveAsync())
            {
                return ApiResponse<PaymentResponse>.Success(Common.DeleteSuccess);
            }
            else
            {
                throw new BadRequestException(Common.DeleteFailure);
            }
        }

        public async Task<PagedResponse<PaymentResponse>> Filter(FilterBaseRequest request)
        {
            var payments = _paymentRepository.GetQueryable();
            var paged = await PagedResponse<Payment>.CreateAsync(payments, request.PageIndex, request.PageSize);
            var response = _mapper.Map<PagedResponse<PaymentResponse>>(paged);
            return response;
        }

        public async Task<ApiResponse<List<PaymentResponse>>> GetAll()
        {
            var alls = await _paymentRepository.GetAllAsync();
            var response = _mapper.Map<List<PaymentResponse>>(alls);
            return ApiResponse<List<PaymentResponse>>.Success(response);
        }

        public async Task<ApiResponse<PaymentResponse>> GetById(Guid id)
        {
            var payment = await _paymentRepository.GetByIdAsync(id);
            if (payment == null) throw new NotFoundException(Common.NotFound);

            var response = _mapper.Map<PaymentResponse>(payment);
            return ApiResponse<PaymentResponse>.Success(response);
        }

        public async Task<ApiResponse<PaymentResponse>> Update(UpdatePaymentRequest request)
        {
            var payment = _mapper.Map<Payment>(request);
            payment.UpdatedDate = DateTime.Now;
            _paymentRepository.Update(payment);
            if (await _paymentRepository.SaveAsync())
            {
                return ApiResponse<PaymentResponse>.Success(Common.UpdateSuccess);
            }
            else
            {
                throw new BadRequestException(Common.UpdateFailure);
            }
        }
    }
}
