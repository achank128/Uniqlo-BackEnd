using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniqlo.Models.RequestModels.ProductDetail
{
    public class UpdateProductDetailRequest
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public int SizeId { get; set; }
        public int ColorId { get; set; }
        public bool StockStatus { get; set; }
        public int InStock { get; set; }
        public int Sold { get; set; }
        public string? Description { get; set; }
    }
}
