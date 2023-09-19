using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.Models.EntityModels;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels.Size;
using Uniqlo.Models.ResponseModels;

namespace Uniqlo.BusinessLogic.MappingProfiles
{
    public class SizeProfile : Profile
    {
        public SizeProfile()
        {
            CreateMap<CreateSizeRequest, Size>();
            CreateMap<UpdateSizeRequest, Size>();
            CreateMap<Size, SizeResponse>();
            CreateMap<PagedResponse<Size>, PagedResponse<SizeResponse>>();
        }
    }
}
