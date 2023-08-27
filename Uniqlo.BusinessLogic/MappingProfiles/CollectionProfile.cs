using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.Models.EntityModels;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels.Collection;
using Uniqlo.Models.ResponseModels;

namespace Uniqlo.BusinessLogic.MappingProfiles
{
    public class CollectionProfile : Profile
    {
        public CollectionProfile()
        {
            CreateMap<CreateCollectionRequest, Collection>();
            CreateMap<UpdateCollectionRequest, Collection>();
            CreateMap<Collection, CollectionResponse>();
            CreateMap<PagedResponse<Collection>, PagedResponse<CollectionResponse>>();
        }
    }
}
