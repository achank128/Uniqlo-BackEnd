using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniqlo.Models.EntityModels
{
    public class CartItem
    {
        [Key]
        public Guid Id { get; set; }
        public Guid CartId { get; set; }
        public Guid ProductDetailId { get; set; }
        public int Quantity { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; } = DateTime.Now;


        public virtual Cart Cart { get; set; }

        public virtual ProductDetail ProductDetail { get; set; }
    }
}
