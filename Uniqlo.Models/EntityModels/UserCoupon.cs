using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniqlo.Models.EntityModels
{
    public class UserCoupon
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid CouponId { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; } = DateTime.Now;


        public virtual User User { get; set; }
        public virtual Coupon Coupon { get; set; }

    }
}
