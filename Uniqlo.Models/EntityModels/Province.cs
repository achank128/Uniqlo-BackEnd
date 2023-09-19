using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniqlo.Models.EntityModels
{
    [Table("provinces")]
    public class Province
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
        [Column("administrative_unit_id")]
        public int? AdministrativeUnitId { get; set; }
        [Column("administrative_region_id")]
        public int? AdministrativeRegionId { get; set; }

        public virtual AdministrativeUnit AdministrativeUnit { get; set; }
        public virtual AdministrativeRegion AdministrativeRegion { get; set; }

        public ICollection<District> Districts { get; set; } = new List<District>();
        public virtual ICollection<UserAddress> UserAddresses { get; set; } = new List<UserAddress>();


    }
}
