using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniqlo.Models.RequestModels.Product
{
    public class CreateProductCrawlRequest
    {
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
        public int UnitId { get; set; }
        public string For { get; set; }
        public List<string> ImageList { get; set; }
        public List<string> SizeList { get; set; }
        public List<string> ColorList { get; set; }
        public decimal Price { get; set; }
        public decimal? PromoPrice { get; set; }
        public decimal? ImportPrice { get; set; }
        public decimal? VAT { get; set; }
        public float Star { get; set; }
        public int Amount { get; set; }
        public Guid? CollectionId { get; set; }
    }
}
