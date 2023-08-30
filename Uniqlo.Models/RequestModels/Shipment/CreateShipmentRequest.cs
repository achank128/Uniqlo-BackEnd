using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniqlo.Models.RequestModels.Shipment
{
    public class CreateShipmentRequest
    {
        public Guid OrderId { get; set; }
        public Guid UserAddressId { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public string? Details { get; set; }
        public int Amount { get; set; }
        public decimal ShipmentPay { get; set; }
        public string Status { get; set; }
        public string? StatusDetails { get; set; }
    }
}
