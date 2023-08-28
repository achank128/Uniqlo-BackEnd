using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.Models.EntityModels;

namespace Uniqlo.Models.ResponseModels
{
    public class ProductResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? NameEn { get; set; }
        public string? NameVi { get; set; }
        public string? Description { get; set; }
        public string? DescriptionEn { get; set; }
        public string? DescriptionVi { get; set; }
        public string? Overview { get; set; }
        public string? OverviewEn { get; set; }
        public string? OverviewVi { get; set; }
        public string? Materials { get; set; }
        public string? MaterialsEn { get; set; }
        public string? MaterialsVi { get; set; }
        public bool IsSale { get; set; }
        public bool IsOnlineOnly { get; set; }
        public bool IsLimited { get; set; }
        public int UnitId { get; set; }
        public int GenderTypeId { get; set; }
        public Guid ProductPriceId { get; set; }
        public Guid? ProductReviewId { get; set; }
        public Guid? CollectionId { get; set; }
        public bool? DeleteStatus { get; set; } 
        public string? Status { get; set; } 
        public DateTime? CreatedDate { get; set; } 
        public DateTime? UpdatedDate { get; set; } 


        public virtual Unit Unit { get; set; }
        public virtual GenderType GenderType { get; set; }
        public virtual ProductPriceResponse ProductPrice { get; set; }
        public virtual ProductReviewResponse? ProductReview { get; set; }
        public virtual Collection? Collection { get; set; }
    }
}
