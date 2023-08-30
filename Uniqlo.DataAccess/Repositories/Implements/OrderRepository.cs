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
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        private readonly UniqloContext _context;
        public OrderRepository(UniqloContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Order> GetOrderByIdAsync(Guid id)
        {
            var order = await _context.Orders
               .Where(o => o.Id == id)
               .Include(o => o.Payments)
               .Include(o => o.User)
               .Include(o => o.Coupon)
               .Include(o => o.Shipments)
               .ThenInclude(sm => sm.UserAddress)
               .Include(o => o.OrderItems)
               .ThenInclude(oi => oi.ProductDetail)
               .ThenInclude(pd => pd.Product)
               .SingleOrDefaultAsync();
            return order;
        }
    }
}
