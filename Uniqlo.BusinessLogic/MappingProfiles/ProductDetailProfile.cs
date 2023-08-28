using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.Models.EntityModels;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels.ProductDetail;
using Uniqlo.Models.ResponseModels;

namespace Uniqlo.BusinessLogic.MappingProfiles
{
    public class ProductDetailProfile : Profile
    {
        public ProductDetailProfile()
        {
            CreateMap<CreateProductDetailRequest, ProductDetail>();
            CreateMap<CreateListProductDetailRequest, ProductDetail>();
            CreateMap<UpdateProductDetailRequest, ProductDetail>();
            CreateMap<ProductDetail, ProductDetailResponse>();
            CreateMap<PagedResponse<ProductDetail>, PagedResponse<ProductDetailResponse>>();
        }
    }
}
