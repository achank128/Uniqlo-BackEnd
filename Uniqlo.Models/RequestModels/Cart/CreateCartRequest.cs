using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniqlo.Models.RequestModels.Cart
{
    public class CreateCartRequest
    {
        public Guid UserId { get; set; }
        public int Amount { get; set; }
        public string? Description { get; set; }
    }
}
