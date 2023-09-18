using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniqlo.Models.ResponseModels
{
    public class ReviewResponse
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }
        public int Star { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int SizeId { get; set; }
        public int Fit { get; set; }
        public DateTime? CreatedDate { get; set; } 
        public DateTime? UpdatedDate { get; set; }

        public virtual SizeResponse Size { get; set; }
    }
}
