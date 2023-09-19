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
using Uniqlo.Models.RequestModels.Shipment;

namespace Uniqlo.DataAccess.Repositories.Implements
{
    public class ShipmentRepository : RepositoryBase<Shipment>, IShipmentRepository
    {
        private readonly UniqloContext _context;

        public ShipmentRepository(UniqloContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Shipment> FilterShipments(FilterShipmentRequest filter)
        {
            var shipments = from o in _context.Shipments
                         where (filter.ShipmentStatus == null || o.Status == filter.ShipmentStatus)
                         select o;

            _context.ChangeTracker.LazyLoadingEnabled = false;
            _context.ChangeTracker.AutoDetectChangesEnabled = false;
            shipments.Include(o => o.UserAddress).Load();

            return shipments;
        }

        public async Task<Shipment> GetShipmentById(Guid id)
        {
            var order = _context.Shipments.Where(o => o.Id == id);

            _context.ChangeTracker.LazyLoadingEnabled = false;
            _context.ChangeTracker.AutoDetectChangesEnabled = false;
            order.Include(o => o.UserAddress).ThenInclude(s => s.Province).Load();
            order.Include(o => o.UserAddress).ThenInclude(s => s.District).Load();
            order.Include(o => o.UserAddress).ThenInclude(s => s.Ward).Load();

            return await order.SingleOrDefaultAsync();
        }

        public async Task<Shipment> GetShipmentByOrder(Guid orderId)
        {
            var order = _context.Shipments.Where(o => o.OrderId == orderId);

            _context.ChangeTracker.LazyLoadingEnabled = false;
            _context.ChangeTracker.AutoDetectChangesEnabled = false;
            order.Include(o => o.UserAddress).ThenInclude(s => s.Province).Load();
            order.Include(o => o.UserAddress).ThenInclude(s => s.District).Load();
            order.Include(o => o.UserAddress).ThenInclude(s => s.Ward).Load();

            return await order.FirstOrDefaultAsync();
        }
    }
}
