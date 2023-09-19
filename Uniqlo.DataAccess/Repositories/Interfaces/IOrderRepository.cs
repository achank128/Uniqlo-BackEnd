using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.DataAccess.RepositoryBase;
using Uniqlo.Models.EntityModels;
using Uniqlo.Models.RequestModels.Order;

namespace Uniqlo.DataAccess.Repositories.Interfaces
{
    public interface IOrderRepository : IRepositoryBase<Order>
    {
        IQueryable<Order> FilterOrders(FilterOrderRequest filter);
        Task<Order> GetOrderById(Guid id);
        Task<List<Order>> GetOrderByUser(Guid userId);
    }
}
