using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.DataAccess.RepositoryBase;
using Uniqlo.Models.EntityModels;

namespace Uniqlo.DataAccess.Repositories.Interfaces
{
    public interface ICartRepository : IRepositoryBase<Cart>
    {
        void CreateCart(Cart cart);
        Task<Cart> GetCartById(Guid id);
        Task<Cart> GetCartByUser(Guid userId);
        void DeleteItemsFormCart(Guid id);
    }
}
