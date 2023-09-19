using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniqlo.Models.RequestModels.OrderItem
{
    public class CreateOrderItemRequest
    {
        public Guid OrderId { get; set; }
        public Guid ProductDetailId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
