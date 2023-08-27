using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniqlo.Models.EntityModels
{
    public class Payment
    {
        [Key]
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public string PaymentType { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string? CreditCardName { get; set; }
        public string? CreditCardType { get; set; }
        public string? CreditCardDate { get; set; }
        public string? CreditCardNumber { get; set; }
        public string? CreditCardNumberDisplay { get; set; }
        public string? Note { get; set; }
        public string? Status { get; set; } = "UNPAID";
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; } = DateTime.Now;

        public virtual Order Order { get; set; }
    }
}
