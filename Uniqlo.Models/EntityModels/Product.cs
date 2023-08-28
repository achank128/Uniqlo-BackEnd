using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniqlo.Models.EntityModels
{
    public class Product
    {
        [Key]
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
        public bool IsSale { get; set; } = false;
        public bool IsOnlineOnly { get; set; } = false;
        public bool IsLimited { get; set; } = false;
        public int UnitId { get; set; }
        public int GenderTypeId { get; set; }
        public Guid ProductPriceId { get; set; }
        public Guid? ProductReviewId { get; set; }
        public Guid? CollectionId { get; set; }
        public bool? DeleteStatus { get; set; } = false;
        public string? Status { get; set; } = "ACTIVE";
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; } = DateTime.Now;


        public virtual Unit Unit { get; set; }
        public virtual GenderType GenderType { get; set; }
        public virtual ProductPrice ProductPrice { get; set; }
        public virtual ProductReview? ProductReview { get; set; }
        public virtual Collection? Collection { get; set; }

        public virtual ICollection<ProductSize> ProductSizes { get; set; } = new List<ProductSize>();
        public virtual ICollection<ProductColor> ProductColors { get; set; } = new List<ProductColor>();
        public virtual ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();
        public virtual ICollection<ProductDetail> ProductDetails { get; set; } = new List<ProductDetail>();
        public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
        public virtual ICollection<WishList> WishLists { get; set; } = new List<WishList>();
        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    }
}
