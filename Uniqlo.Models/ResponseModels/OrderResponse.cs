﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.Models.EntityModels;

namespace Uniqlo.Models.ResponseModels
{
    public class OrderResponse
    {
        public Guid Id { get; set; }
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
        public string? CancelReason { get; set; }
        public bool IsPaid { get; set; } 
        public bool DeleteStatus { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual UserResponse User { get; set; }
        public virtual CouponResponse? Coupon { get; set; }
        public virtual List<OrderItemResponse> OrderItems { get; set; }
        public virtual List<PaymentResponse> Payments { get; set; } 
        public virtual List<ShipmentResponse> Shipments { get; set; }

    }
}
