using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniqlo.Models.RequestModels.Product
{
    public class CreateProductFullRequest
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
        public bool IsOnlineOnly { get; set; } 
        public bool IsLimited { get; set; }
        public int UnitId { get; set; }
        public int GenderTypeId { get; set; }
        public decimal Price { get; set; }
        public decimal? PromoPrice { get; set; }
        public decimal? ImportPrice { get; set; }
        public decimal? VAT { get; set; }
        public Guid? CollectionId { get; set; }
        public string? Status { get; set; }
        public List<int> Sizes { get; set; }
        public List<int> Colors { get; set; }
        public List<Guid> Categories { get; set; }
    }
}
