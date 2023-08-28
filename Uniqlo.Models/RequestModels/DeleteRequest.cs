using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniqlo.Models.RequestModels
{
    public class DeleteRequest
    {
        public bool DeleteStatus { get; set; }
        public string DeleteReason { get; set; }
    }
}
