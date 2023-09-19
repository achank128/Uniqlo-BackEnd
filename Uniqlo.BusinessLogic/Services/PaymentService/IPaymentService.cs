using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels.Coupon;
using Uniqlo.Models.RequestModels.Payment;
using Uniqlo.Models.ResponseModels;

namespace Uniqlo.BusinessLogic.Services.PaymentService
{
    public interface IPaymentService
    {
        Task<ApiResponse<PaymentResponse>> Create(CreatePaymentRequest request);
        Task<PagedResponse<PaymentResponse>> Filter(FilterBaseRequest request);
        Task<ApiResponse<List<PaymentResponse>>> GetAll();
        Task<ApiResponse<PaymentResponse>> GetById(Guid id);
        Task<ApiResponse<PaymentResponse>> Update(UpdatePaymentRequest request);
        Task<ApiResponse<PaymentResponse>> Delete(Guid id);
    }
}
