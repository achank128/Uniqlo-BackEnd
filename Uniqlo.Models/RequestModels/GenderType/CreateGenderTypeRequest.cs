using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniqlo.Models.RequestModels.GenderType
{
    public class CreateGenderTypeRequest
    {
        public string Name { get; set; }
        public string? NameEn { get; set; }
        public string? NameVi { get; set; }
    }
}
