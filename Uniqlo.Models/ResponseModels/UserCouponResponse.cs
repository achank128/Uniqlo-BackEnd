using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.Models.EntityModels;

namespace Uniqlo.Models.ResponseModels
{
    public class UserCouponResponse
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid CouponId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public virtual CouponResponse Coupon { get; set; }

    }
}
