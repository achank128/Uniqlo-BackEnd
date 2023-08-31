using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniqlo.Models.RequestModels.CollectionPost
{
    public class UploadCollectionPostRequest
    {
        public Guid CollectionId { get; set; }
        public string Title { get; set; }
        public string? TitleEn { get; set; }
        public string? TitleVi { get; set; }
        public string? Description { get; set; }
        public string? DescriptionEn { get; set; }
        public string? DescriptionVi { get; set; }
        public string Type { get; set; }
        public IFormFile Image { get; set; }
    }
}
