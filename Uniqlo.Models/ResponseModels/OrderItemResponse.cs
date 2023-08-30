using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.Models.EntityModels;

namespace Uniqlo.Models.ResponseModels
{
    public class OrderItemResponse
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductDetailId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime? CreatedDate { get; set; } 
        public DateTime? UpdatedDate { get; set; }
        public virtual ProductDetailResponse ProductDetail { get; set; }

    }
}
