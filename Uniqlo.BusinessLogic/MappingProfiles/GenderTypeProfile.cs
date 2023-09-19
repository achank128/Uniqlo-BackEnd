using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.Models.EntityModels;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels.GenderType;
using Uniqlo.Models.RequestModels.Unit;
using Uniqlo.Models.ResponseModels;

namespace Uniqlo.BusinessLogic.MappingProfiles
{
    public class GenderTypeProfile : Profile
    {
        public GenderTypeProfile()
        {
            CreateMap<CreateGenderTypeRequest, GenderType>();
            CreateMap<UpdateGenderTypeRequest, GenderType>();
            CreateMap<GenderType, GenderTypeResponse>();
            CreateMap<PagedResponse<GenderType>, PagedResponse<GenderTypeResponse>>();
        }
    }
}
