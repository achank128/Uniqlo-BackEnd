using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniqlo.Models.RequestModels.Order
{
    public class UpdateOrderStatusRequest
    {
        public Guid Id { get; set; }
        public string Reason { get; set; } = string.Empty;
        public string Status { get; set; }
    }
}
