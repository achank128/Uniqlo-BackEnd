﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.DataAccess.RepositoryBase;
using Uniqlo.Models.EntityModels;

namespace Uniqlo.DataAccess.Repositories.Interfaces
{
    public interface IOrderItemRepository : IRepositoryBase<OrderItem>
    {
        Task<OrderItem> GetOrderItemById(Guid id);
        Task<List<OrderItem>> GetOrderItemByOrder(Guid orderId);
    }
}
