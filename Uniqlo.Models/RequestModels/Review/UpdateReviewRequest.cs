using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniqlo.Models.RequestModels.Review
{
    public class UpdateReviewRequest
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }
        public int Star { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int SizeId { get; set; }
        public int Fit { get; set; }
    }
}
