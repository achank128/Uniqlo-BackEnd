using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.Models.RequestModels.OrderItem;

namespace Uniqlo.Models.RequestModels.Order
{
    public class CreateOrderFullRequest
    {
        public Guid UserId { get; set; }
        public string? Note { get; set; }
        public int Items { get; set; }
        public int Amount { get; set; }
        public decimal Subtotal { get; set; }
        public Guid? CouponId { get; set; }
        public decimal? Discount { get; set; }
        public decimal ShippingFee { get; set; }
        public decimal Total { get; set; }
        public decimal VATIncluded { get; set; }
        public string Status { get; set; }

        //Shipment
        public Guid UserAddressId { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public decimal ShipmentPay { get; set; }
        public string? ShipmentNote { get; set; }

        //Payment
        public string PaymentType { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string? CreditCardName { get; set; }
        public string? CreditCardType { get; set; }
        public string? CreditCardDate { get; set; }
        public string? CreditCardNumber { get; set; }
        public string? CreditCardNumberDisplay { get; set; }
        public string? PaymentNote { get; set; }

        //Items
        public List<CreateOrderItemRequest> OrderItems { get; set; }
    }
}
