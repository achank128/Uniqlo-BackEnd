using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniqlo.Models.ResponseModels
{
    public class ShipmentResponse
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid UserAddressId { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public string? Details { get; set; }
        public int Amount { get; set; }
        public decimal ShipmentPay { get; set; }
        public string Status { get; set; } 
        public string? StatusDetails { get; set; }
        public DateTime? CreatedDate { get; set; } 
        public DateTime? UpdatedDate { get; set; }
        public virtual UserAddressResponse UserAddress { get; set; }

    }
}
