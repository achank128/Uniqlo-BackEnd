using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniqlo.Models.EntityModels
{
    public class ImportBillItem
    {
        [Key]
        public Guid Id { get; set; }
        public Guid ImportBillId { get; set; }
        public Guid ProductDetailId { get; set; }
        public int Quantity { get; set; }
        [Column(TypeName = "money")]
        public decimal ImportPrice { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; } = DateTime.Now;


        public virtual ImportBill ImportBill { get; set; }
        public virtual ProductDetail ProductDetail { get; set; }

    }
}
