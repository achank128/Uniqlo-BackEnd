using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniqlo.Models.Models
{
    public class FilterBaseRequest
    {
        public string? KeyWord { get; set; }
        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }
        public Dictionary<string, object>? CustomFilter { get; set; }
    }
}
