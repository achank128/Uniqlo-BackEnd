using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniqlo.Models.RequestModels.ProductDetail
{
    public class CreateListProductDetailRequest
    {
        public Guid ProductId { get; set; }
        public List<int> Sizes { get; set; }
        public List<int> Colors { get; set; }
        public int InStock { get; set; }
    }
}
