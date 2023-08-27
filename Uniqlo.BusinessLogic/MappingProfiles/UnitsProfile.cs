using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.Models.EntityModels;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels.Unit;
using Uniqlo.Models.ResponseModels;

namespace Uniqlo.BusinessLogic.MappingProfiles
{
    public class UnitsProfile : Profile
    {
        public UnitsProfile()
        {
            CreateMap<CreateUnitRequest, Unit>();
            CreateMap<UpdateUnitRequest, Unit>();
            CreateMap<Unit, UnitResponse>();
            CreateMap<PagedResponse<Unit>, PagedResponse<UnitResponse>>();
        }
    }
}
