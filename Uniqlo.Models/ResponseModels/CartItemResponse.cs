using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.Models.EntityModels;

namespace Uniqlo.Models.ResponseModels
{
    public class CartItemResponse
    {
        public Guid Id { get; set; }
        public Guid CartId { get; set; }
        public Guid ProductDetailId { get; set; }
        public int Quantity { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual ProductResponse Product { get; set; }
        public virtual ProductDetailResponse ProductDetail { get; set; }

    }
}
