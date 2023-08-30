using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniqlo.Models.EntityModels
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string? Note { get; set; }
        public int Items { get; set; }
        public int Amount { get; set; }
        [Column(TypeName = "money")]
        public decimal Subtotal { get; set; }
        public Guid? CouponId { get; set; }
        [Column(TypeName = "money")]
        public decimal? Discount { get; set; }
        [Column(TypeName = "money")]
        public decimal ShippingFee { get; set; }
        [Column(TypeName = "money")]
        public decimal Total { get; set; }
        [Column(TypeName = "money")]
        public decimal VATIncluded { get; set; }
        public string Status { get; set; } = "OPEN";
        public string? CancelReason { get; set; }
        public bool IsPaid { get; set; } = false;
        public bool DeleteStatus { get; set; } = false;
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; } = DateTime.Now;


        public virtual User User { get; set; }
        public virtual Coupon? Coupon { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
        public virtual ICollection<Shipment> Shipments { get; set; } = new List<Shipment>();

    }
}
