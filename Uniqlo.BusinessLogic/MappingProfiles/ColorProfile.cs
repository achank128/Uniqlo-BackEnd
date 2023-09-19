using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.Models.EntityModels;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels.Color;
using Uniqlo.Models.ResponseModels;

namespace Uniqlo.BusinessLogic.MappingProfiles
{
    public class ColorProfile : Profile
    {
        public ColorProfile()
        {
            CreateMap<CreateColorRequest, Color>();
            CreateMap<UpdateColorRequest, Color>();
            CreateMap<Color, ColorResponse>();
            CreateMap<PagedResponse<Color>, PagedResponse<ColorResponse>>();
        }
    }
}
