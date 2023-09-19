using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniqlo.Models.RequestModels.Order
{
    public class CancelOrderRequest
    {
        public Guid Id { get; set; }
        public string CancelReason { get; set; }
    }
}
