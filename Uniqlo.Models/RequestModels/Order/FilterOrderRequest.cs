using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.Models.Models;

namespace Uniqlo.Models.RequestModels.Order
{
    public class FilterOrderRequest : FilterBaseRequest
    {
        public Guid? ProductId { get; set; }
        public string? OrderStatus { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
