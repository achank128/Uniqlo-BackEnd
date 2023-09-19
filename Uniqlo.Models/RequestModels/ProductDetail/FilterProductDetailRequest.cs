using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.Models.Models;

namespace Uniqlo.Models.RequestModels.ProductDetail
{
    public class FilterProductDetailRequest : FilterBaseRequest
    {
        public Guid? ProductId { get; set; }
        public int? SizeId { get; set; }
        public int? ColorId { get; set; }
    }
}
