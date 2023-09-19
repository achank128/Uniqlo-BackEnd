using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniqlo.Models.RequestModels.WishList
{
    public class CreateWishListRequest
    {
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }
    }
}
