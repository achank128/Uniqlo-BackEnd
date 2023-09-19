using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniqlo.Models.RequestModels.Coupon
{
    public class CreateCouponRequest
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public string? TitleEn { get; set; }
        public string? TitleVi { get; set; }
        public string? Description { get; set; }
        public string? DescriptionEn { get; set; }
        public string? DescriptionVi { get; set; }
        public int? Percent { get; set; }
        public decimal? Discount { get; set; }
        public decimal? Max { get; set; }
        public decimal? TotalFrom { get; set; }
        public int? Amount { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsExpired { get; set; }
        public string Type { get; set; }
    }
}
