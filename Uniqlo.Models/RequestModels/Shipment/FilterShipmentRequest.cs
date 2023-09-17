using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.Models.Models;

namespace Uniqlo.Models.RequestModels.Shipment
{
    public class FilterShipmentRequest : FilterBaseRequest
    {
        public string? ShipmentStatus { get; set; }
    }
}
