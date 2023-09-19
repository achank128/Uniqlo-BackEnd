using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniqlo.Models.EntityModels
{
    public class Collection
    {
        [Key]
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
        public bool IsShow { get; set; } = false;
        public bool DeleteStatus { get; set; } = false;
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; } = DateTime.Now;


        public virtual ICollection<CollectionPost> CollectionPosts { get; set; } = new List<CollectionPost>();
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    }
}
