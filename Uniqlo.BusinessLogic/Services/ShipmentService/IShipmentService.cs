using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels.Coupon;
using Uniqlo.Models.RequestModels.Shipment;
using Uniqlo.Models.ResponseModels;

namespace Uniqlo.BusinessLogic.Services.ShipmentService
{
    public interface IShipmentService
    {
        Task<ApiResponse<ShipmentResponse>> Create(CreateShipmentRequest request);
        Task<PagedResponse<ShipmentResponse>> Filter(FilterBaseRequest request);
        Task<ApiResponse<List<ShipmentResponse>>> GetAll();
        Task<ApiResponse<ShipmentResponse>> GetById(Guid id);
        Task<ApiResponse<ShipmentResponse>> Update(UpdateShipmentRequest request);
        Task<ApiResponse<ShipmentResponse>> Delete(Guid id);
    }
}
