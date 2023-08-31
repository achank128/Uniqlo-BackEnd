using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniqlo.Models.RequestModels.ProductImage
{
    public class UploadProductImageRequest
    {
        public Guid ProductId { get; set; }
        public string Type { get; set; }
        public List<IFormFile> Images { get; set; }

    }
}
