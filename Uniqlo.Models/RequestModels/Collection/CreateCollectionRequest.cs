using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniqlo.Models.RequestModels.Collection
{
    public class CreateCollectionRequest
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string? Description { get; set; }
        public string? Content { get; set; }
        public string Author { get; set; }
    }
}
