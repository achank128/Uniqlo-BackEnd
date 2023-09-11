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
    public class OrderItemRepository : RepositoryBase<OrderItem>, IOrderItemRepository
    {
        private readonly UniqloContext _context;
        public OrderItemRepository(UniqloContext context) : base(context)
        {
            _context = context;
        }

        public async Task<OrderItem> GetOrderItemById(Guid id)
        {
            var orderItem = await _context.OrderItems.Where(s => s.Id == id)
                .Include(s => s.ProductDetail)
                .SingleOrDefaultAsync();

            return orderItem;
        }

        public async Task<List<OrderItem>> GetOrderItemByOrder(Guid orderId)
        {
            var orderItem = await _context.OrderItems.Where(s => s.OrderId == orderId)
                .Include(s => s.ProductDetail).ThenInclude(pd => pd.Color)
                .Include(s => s.ProductDetail).ThenInclude(pd => pd.Size)
                .ToListAsync();

            return orderItem;
        }
    }
}
