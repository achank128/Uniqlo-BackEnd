using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.DataAccess.RepositoryBase;
using Uniqlo.Models.EntityModels;
using Uniqlo.Models.RequestModels.Shipment;

namespace Uniqlo.DataAccess.Repositories.Interfaces
{
    public interface IShipmentRepository : IRepositoryBase<Shipment>
    {
        IQueryable<Shipment> FilterShipments(FilterShipmentRequest filter);
        Task<Shipment> GetShipmentById(Guid id);
        Task<Shipment> GetShipmentByOrder(Guid orderId);
    }
}
