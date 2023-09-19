using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniqlo.Models.RequestModels.ProductImage
{
    public class CreateProductImageRequest
    {
        public Guid ProductId { get; set; }
        public string Image { get; set; }
        public string ImageUrl { get; set; }
        public string Type { get; set; } 
    }
}
