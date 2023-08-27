using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniqlo.Models.EntityModels
{
    public class Shipment
    {
        [Key]
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid UserAddressId { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public string? Details { get; set; }
        public int Amount { get; set; }
        [Column(TypeName = "money")]
        public decimal ShipmentPay { get; set; }
        public string Status { get; set; } = "PENDING";
        public string? StatusDetails { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; } = DateTime.Now;


        public virtual Order Order { get; set; }
        public virtual UserAddress UserAddress { get; set; }
    }
}
