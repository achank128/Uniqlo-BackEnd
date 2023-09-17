using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.Models.EntityModels;

namespace Uniqlo.Models.ResponseModels
{
    public class ProductDetailResponse
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public int SizeId { get; set; }
        public int ColorId { get; set; }
        public bool StockStatus { get; set; }
        public int InStock { get; set; }
        public int Sold { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }


        public virtual ProductResponse Product { get; set; }
        public virtual SizeResponse Size { get; set; }
        public virtual ColorResponse Color { get; set; }
    }
}
