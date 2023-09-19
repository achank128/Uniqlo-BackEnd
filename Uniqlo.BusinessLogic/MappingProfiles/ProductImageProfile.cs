using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.Models.EntityModels;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels.CollectionPost;
using Uniqlo.Models.RequestModels.ProductImage;
using Uniqlo.Models.ResponseModels;

namespace Uniqlo.BusinessLogic.MappingProfiles
{
    public class ProductImageProfile : Profile
    {
        public ProductImageProfile()
        {
            CreateMap<CreateProductImageRequest, ProductImage>();
            CreateMap<UpdateProductImageRequest, ProductImage>();
            CreateMap<ProductImage, ProductImageResponse>();
            CreateMap<PagedResponse<ProductImage>, PagedResponse<ProductImageResponse>>();
        }
    }
}
