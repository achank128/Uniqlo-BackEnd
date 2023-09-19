using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniqlo.Models.ResponseModels
{
    public class ProductColorResponse
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public int ColorId { get; set; }
        public DateTime? CreatedDate { get; set; } 
        public DateTime? UpdatedDate { get; set; }

        public virtual ColorResponse Color { get; set; }

    }
}
