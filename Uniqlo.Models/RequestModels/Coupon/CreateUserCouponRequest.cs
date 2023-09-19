using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniqlo.Models.RequestModels.Coupon
{
    public class CreateUserCouponRequest
    {
        public Guid UserId { get; set; }
        public Guid CouponId { get; set; }
    }
}
