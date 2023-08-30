using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.Models.EntityModels;
using Uniqlo.Models.ResponseModels;

namespace Uniqlo.BusinessLogic.MappingProfiles
{
    public class RegionProfile : Profile   
    {
        public RegionProfile()
        {
            CreateMap<Province, ProvinceResponse>();
            CreateMap<District, DistrictResponse>();
            CreateMap<Ward, WardResponse>();

        }
    }
}
