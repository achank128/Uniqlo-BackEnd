using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.Models.EntityModels;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels.Cart;
using Uniqlo.Models.RequestModels.CollectionPost;
using Uniqlo.Models.ResponseModels;

namespace Uniqlo.BusinessLogic.MappingProfiles
{
    public class CollectionPostProfile : Profile
    {
        public CollectionPostProfile()
        {
            CreateMap<CreateCollectionPostRequest, CollectionPost>();
            CreateMap<UpdateCollectionPostRequest, CollectionPost>();
            CreateMap<CollectionPost, CollectionPostResponse>();
            CreateMap<PagedResponse<CollectionPost>, PagedResponse<CollectionPostResponse>>();
        }
    }
}
