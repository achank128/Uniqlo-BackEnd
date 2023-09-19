using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniqlo.Models.RequestModels.Payment
{
    public class CreatePaymentRequest
    {
        public Guid OrderId { get; set; }
        public string PaymentType { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string? CreditCardName { get; set; }
        public string? CreditCardType { get; set; }
        public string? CreditCardDate { get; set; }
        public string? CreditCardNumber { get; set; }
        public string? CreditCardNumberDisplay { get; set; }
        public string? Note { get; set; }
        public string? Status { get; set; }
    }
}
