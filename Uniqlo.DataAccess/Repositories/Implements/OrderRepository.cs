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
using Uniqlo.Models.RequestModels.Order;

namespace Uniqlo.DataAccess.Repositories.Implements
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        private readonly UniqloContext _context;
        public OrderRepository(UniqloContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Order> FilterOrders(FilterOrderRequest filter)
        {
            var orders = from o in _context.Orders 
                         where (filter.StartDate == null || o.CreatedDate > filter.StartDate)
                         && (filter.EndDate == null || o.CreatedDate < filter.EndDate)
                         && (filter.OrderStatus == null || o.Status == filter.OrderStatus)
                         select o;

            _context.ChangeTracker.LazyLoadingEnabled = false;
            _context.ChangeTracker.AutoDetectChangesEnabled = false;
            orders.Include(o => o.User).Load();
            orders.Include(o => o.Coupon).Load();
            orders.Include(o => o.Payments).Load();
            orders.Include(o => o.Shipments).Load();

            return orders;
        }

        public async Task<Order> GetOrderById(Guid id)
        {
            var order = _context.Orders.Where(o => o.Id == id);

            _context.ChangeTracker.LazyLoadingEnabled = false;
            _context.ChangeTracker.AutoDetectChangesEnabled = false;
            order.Include(o => o.User).Load();
            order.Include(o => o.Coupon).Load();
            order.Include(o => o.Payments).Load();
            order.Include(o => o.Shipments).Load();
            order.Include(o => o.OrderItems).ThenInclude(s => s.ProductDetail).ThenInclude(pd => pd.Color).Load();
            order.Include(o => o.OrderItems).ThenInclude(s => s.ProductDetail).ThenInclude(pd => pd.Size).Load();
            order.Include(o => o.OrderItems).ThenInclude(s => s.ProductDetail).ThenInclude(pd => pd.Product).ThenInclude(p => p.ProductImages).Load();

            return await order.SingleOrDefaultAsync();
        }

        public async Task<List<Order>> GetOrderByUser(Guid userId)
        {
            var orders =_context.Orders.Where(o => o.UserId == userId).OrderByDescending(o => o.CreatedDate);

            _context.ChangeTracker.LazyLoadingEnabled = false;
            _context.ChangeTracker.AutoDetectChangesEnabled = false;
            orders.Include(o => o.Coupon).Load();
            orders.Include(o => o.Payments).Load();
            orders.Include(o => o.Shipments).Load();
            orders.Include(o => o.OrderItems).ThenInclude(s => s.ProductDetail).ThenInclude(pd => pd.Color).Load();
            orders.Include(o => o.OrderItems).ThenInclude(s => s.ProductDetail).ThenInclude(pd => pd.Size).Load();
            orders.Include(o => o.OrderItems).ThenInclude(s => s.ProductDetail).ThenInclude(pd => pd.Product).ThenInclude(p => p.ProductImages).Load();

            return await orders.ToListAsync();
        }
    }
}
