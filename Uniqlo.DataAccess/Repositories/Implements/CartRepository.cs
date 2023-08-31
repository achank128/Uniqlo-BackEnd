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
    public class CartRepository : RepositoryBase<Cart>, ICartRepository
    {
        private readonly UniqloContext _context;
        public CartRepository(UniqloContext context) : base(context)
        {
            _context = context;
        }

        public void DeleteItemsFormCart(Guid id)
        {
            var items = _context.CartItems.Where(x => x.CartId == id).ToList();
            _context.CartItems.RemoveRange(items);
            _context.SaveChanges();
        }

        public async Task<Cart> GetCartById(Guid id)
        {
            var cart = await _context.Carts
                .Where(c => c.Id == id)
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.ProductDetail)
                .ThenInclude(pd => pd.Product)
                .SingleOrDefaultAsync();
            return cart;
        }

        public async Task<Cart> GetCartByUser(Guid userId)
        {
            var cart = await _context.Carts
                .Where(c => c.UserId == userId)
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.ProductDetail)
                .ThenInclude(pd => pd.Product)
                .SingleOrDefaultAsync();
            return cart;
        }
    }
}
