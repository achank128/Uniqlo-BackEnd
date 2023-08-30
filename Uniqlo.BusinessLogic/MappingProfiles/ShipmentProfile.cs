using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.Models.EntityModels;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels.Cart;
using Uniqlo.Models.RequestModels.Shipment;
using Uniqlo.Models.ResponseModels;

namespace Uniqlo.BusinessLogic.MappingProfiles
{
    public class ShipmentProfile : Profile
    {
        public ShipmentProfile()
        {
            CreateMap<CreateShipmentRequest, Shipment>();
            CreateMap<UpdateShipmentRequest, Shipment>();
            CreateMap<Shipment, ShipmentResponse>();
            CreateMap<PagedResponse<Shipment>, PagedResponse<ShipmentResponse>>();
        }
    }
}
