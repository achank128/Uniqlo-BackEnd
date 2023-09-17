using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniqlo.Models.RequestModels.Shipment
{
    public class UpdateShipmentStatusRequest
    {
        public Guid Id { get; set; }
        public string Status { get; set; }
        public string StatusDetail { get; set; } = string.Empty;
    }
}
