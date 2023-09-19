using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniqlo.Models.RequestModels.UserAddress
{
    public class CreateUserAddressRequest
    {
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
    }
}
