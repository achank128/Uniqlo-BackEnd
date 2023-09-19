using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniqlo.Models.RequestModels.Color
{
    public class CreateColorRequest
    {
        public string Name { get; set; }
        public string? NameEn { get; set; }
        public string? NameVi { get; set; }
        public string Code { get; set; }
        public string? Image { get; set; }
        public string? ImageUrl { get; set; }
    }
}
