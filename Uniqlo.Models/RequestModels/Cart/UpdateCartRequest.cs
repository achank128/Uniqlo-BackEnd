using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.Models.RequestModels.CartItem;

namespace Uniqlo.Models.RequestModels.Cart
{
    public class UpdateCartRequest
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public int Amount { get; set; }
        public string? Description { get; set; }
        public List<CreateCartItemRequest> CartItems { get; set; }
    }
}
