using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniqlo.Models.RequestModels.Order
{
    public class UpdateOrderRequest
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string? Note { get; set; }
        public int Amount { get; set; }
        public decimal Subtotal { get; set; }
        public Guid CouponId { get; set; }
        public decimal? Discount { get; set; }
        public decimal ShippingFee { get; set; }
        public decimal Total { get; set; }
        public decimal VATIncluded { get; set; }
        public string Status { get; set; }
        public string? CancelReason { get; set; }
        public bool DeleteStatus { get; set; }
    }
}
