using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.Models.EntityModels;

namespace Uniqlo.Models.ResponseModels
{
    public class UserAddressResponse
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string? Title { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string ProvinceCode { get; set; }
        public string DistrictCode { get; set; }
        public string WardCode { get; set; }
        public string Address { get; set; }
        public string? AddressDetail { get; set; }
        public string? Note { get; set; }
        public bool IsDefault { get; set; }

        public virtual ProvinceResponse Province { get; set; }
        public virtual DistrictResponse District { get; set; }
        public virtual WardResponse Ward { get; set; }
    }
}
