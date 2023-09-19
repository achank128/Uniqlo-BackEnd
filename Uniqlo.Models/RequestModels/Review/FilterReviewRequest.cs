using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.Models.Models;

namespace Uniqlo.Models.RequestModels.Review
{
    public class FilterReviewRequest : FilterBaseRequest
    {
        public Guid? ProductId { get; set; }
        public int? Star { get; set; }
    }
}
