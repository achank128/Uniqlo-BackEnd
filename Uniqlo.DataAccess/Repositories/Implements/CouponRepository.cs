using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.DataAccess.Repositories.Interfaces;
using Uniqlo.DataAccess.RepositoryBase;
using Uniqlo.Models.Context;
using Uniqlo.Models.EntityModels;

namespace Uniqlo.DataAccess.Repositories.Implements
{
    internal class CouponRepository : RepositoryBase<Coupon>, ICouponRepository
    {
        private readonly UniqloContext _context;

        public CouponRepository(UniqloContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Coupon>> GetCouponsByUser(Guid userId)
        {
            var coupons = from c in _context.Coupons
                          join uc in _context.UserCoupons on c.Id equals uc.CouponId into u_ucLeftJoin
                          from u_uc in u_ucLeftJoin.DefaultIfEmpty()
                          where u_uc.UserId == userId || c.Type == "PUBLIC"
                          select c;
            return await coupons.ToListAsync();
        }
    }
}
