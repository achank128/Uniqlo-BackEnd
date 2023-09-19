using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniqlo.Models.EntityModels
{
    [Table("districts")]
    public class District
    {
        [Key]
        [Column("code")]
        public string Code { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("name_en")]
        public string? NameEn { get; set; }
        [Column("full_name")]
        public string FullName { get; set; }
        [Column("full_name_en")]
        public string? FullNameEn { get; set; }
        [Column("code_name")]
        public string? CodeName { get; set; }
        [Column("province_code")]
        public string? ProvinceCode { get; set; }
        [Column("administrative_unit_id")]
        public int? AdministrativeUnitId { get; set; }

        public virtual Province Province { get; set; }
        public virtual AdministrativeUnit AdministrativeUnit { get; set; }

        public ICollection<Ward> Wards { get; set; } = new List<Ward>();
        public virtual ICollection<UserAddress> UserAddresses { get; set; } = new List<UserAddress>();


    }
}
