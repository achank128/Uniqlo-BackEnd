using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniqlo.Models.EntityModels
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Description { get; set; }
        public string? Phone { get; set; }
        public string? Avatar { get; set; }
        public string? AvatarUrl { get; set; }
        public int? Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Address { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; } = DateTime.Now;
        public string Role { get; set; } = "CUSTOMER";


        public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
        public virtual ICollection<ImportBill> ImportBills { get; set; } = new List<ImportBill>();
        public virtual ICollection<WishList> WishLists { get; set; } = new List<WishList>();
        public virtual ICollection<UserCoupon> UserCoupons { get; set; } = new List<UserCoupon>();
        public virtual ICollection<UserAddress> UserAddresses { get; set; } = new List<UserAddress>();
        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
