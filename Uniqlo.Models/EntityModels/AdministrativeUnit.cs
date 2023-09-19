using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniqlo.Models.EntityModels
{
    [Table("administrative_units")]
    public class AdministrativeUnit
    {
        [Key]
        [Column("id")]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("full_name")]
        public string? FullName { get; set; }
        [Column("full_name_en")]
        public string? FullNameEn { get; set; }
        [Column("short_name")]
        public string? ShortName { get; set; }
        [Column("short_name_en")]
        public string? ShortNameEn { get; set; }
        [Column("code_name")]
        public string? CodeName { get; set; }
        [Column("code_name_en")]
        public string? CodeNameEn { get; set; }

        public ICollection<Province> Provinces { get; set; } = new List<Province>();
        public ICollection<District> Districts { get; set; } = new List<District>();
        public ICollection<Ward> Wards { get; set; } = new List<Ward>();

    }
}
