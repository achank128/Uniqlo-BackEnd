using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniqlo.Models.EntityModels
{
    public class ImportBill
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid StoreId { get; set; }
        public string? Note { get; set; }
        [Column(TypeName = "money")]
        public decimal Total { get; set; }
        public DateTime ImportDate { get; set; }
        public string? Status { get; set; } = "COMPLETED";
        public bool? DeleteStatus { get; set; } = false;
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; } = DateTime.Now;

        public virtual User User { get; set; }
        public virtual Store Store { get; set; }

        public virtual ICollection<ImportBillItem> ImportBillItems { get; set; } = new List<ImportBillItem>();
    }
}
