using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniqlo.Models.RequestModels.CartItem
{
    public class UpdateCartItemRequest
    {
        public Guid Id { get; set; }
        public Guid CartId { get; set; }
        public Guid ProductDetailId { get; set; }
        public int Quantity { get; set; }
    }
}
