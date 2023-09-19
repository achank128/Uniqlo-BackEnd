using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniqlo.Models.ResponseModels
{
    public class ProvinceResponse
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string? NameEn { get; set; }
        public string FullName { get; set; }
        public string? FullNameEn { get; set; }
        public string? CodeName { get; set; }
        public int? AdministrativeUnitId { get; set; }
        public int? AdministrativeRegionId { get; set; }
    }
}
