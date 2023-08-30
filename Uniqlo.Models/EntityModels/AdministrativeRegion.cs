using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniqlo.Models.EntityModels
{
    [Table("administrative_regions")]
    public class AdministrativeRegion
    {
        [Key]
        [Column("id")]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("name_en")]
        public string NameEn { get; set; }
        [Column("code_name")]
        public string? CodeName { get; set; }
        [Column("code_name_en")]
        public string? CodeNameEn { get; set; }

        public ICollection<Province> Provinces { get; set; } = new List<Province>();

    }
}
