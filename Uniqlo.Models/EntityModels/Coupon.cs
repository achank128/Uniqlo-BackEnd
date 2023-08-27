using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniqlo.Models.EntityModels
{
    public class Coupon
    {
        [Key]
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public int? Percent { get; set; }
        [Column(TypeName = "money")]
        public decimal? Discount { get; set; }
        [Column(TypeName = "money")]
        public decimal? Max { get; set; }
        [Column(TypeName = "money")]
        public decimal? TotalFrom { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsExpired { get; set; } = false;
        public string Type { get; set; } = "PRIVATE";
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; } = DateTime.Now;

        public virtual ICollection<UserCoupon> UserCoupons { get; set; } = new List<UserCoupon>();
    }
}
