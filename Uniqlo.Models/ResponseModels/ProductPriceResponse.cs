using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniqlo.Models.ResponseModels
{
    public class ProductPriceResponse
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; }
        public decimal? PromoPrice { get; set; }
        public decimal? ImportPrice { get; set; }
        public decimal? VAT { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
