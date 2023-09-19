using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniqlo.Models.ResponseModels
{
    public class CollectionResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? NameEn { get; set; }
        public string? NameVi { get; set; }
        public string Type { get; set; }
        public string? Description { get; set; }
        public string? DescriptionEn { get; set; }
        public string? DescriptionVi { get; set; }
        public string? Content { get; set; }
        public string? ContentEn { get; set; }
        public string? ContentVi { get; set; }
        public string Author { get; set; }
        public bool DeleteStatus { get; set; }
        public bool IsShow { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public List<CollectionPostResponse> CollectionPosts { get; set; }

    }
}
