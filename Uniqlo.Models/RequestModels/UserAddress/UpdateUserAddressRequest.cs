using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniqlo.Models.RequestModels.UserAddress
{
    public class UpdateUserAddressRequest
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string? Title { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string ProvinceId { get; set; }
        public string DistrictId { get; set; }
        public string WardId { get; set; }
        public string Address { get; set; }
        public string? AddressDetail { get; set; }
        public string? Note { get; set; }
        public bool IsDefault { get; set; }
    }
}
