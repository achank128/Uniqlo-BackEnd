using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniqlo.Models.EntityModels
{
    public class UserAddress
    {
        [Key]
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
        public bool IsDefault { get; set; } = false;
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; } = DateTime.Now;


        public virtual User User { get; set; }
        public virtual Province Province { get; set; }
        public virtual District District { get; set; }
        public virtual Ward Ward { get; set; }

        public virtual ICollection<Shipment> Shipments { get; set; } = new List<Shipment>();

    }
}
