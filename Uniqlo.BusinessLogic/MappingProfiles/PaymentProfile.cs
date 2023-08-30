using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.Models.EntityModels;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels.Payment;
using Uniqlo.Models.ResponseModels;

namespace Uniqlo.BusinessLogic.MappingProfiles
{
    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            CreateMap<CreatePaymentRequest, Payment>();
            CreateMap<UpdatePaymentRequest, Payment>();
            CreateMap<Payment, PaymentResponse>();
            CreateMap<PagedResponse<Payment>, PagedResponse<PaymentResponse>>();
        }
    }
}
