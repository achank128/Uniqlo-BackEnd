using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniqlo.Models.RequestModels.Size
{
    public class UpdateSizeRequest
    {
        public int Id { get; set; }
        public int GenderTypeId { get; set; }
        public string Name { get; set; }
        public string? NameEn { get; set; }
        public string? NameVi { get; set; }
        public int Level { get; set; }
    }
}
