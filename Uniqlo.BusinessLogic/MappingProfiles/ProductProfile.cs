using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.Models.EntityModels;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels.Product;
using Uniqlo.Models.ResponseModels;

namespace Uniqlo.BusinessLogic.MappingProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductFullRequest, Product>();
            CreateMap<CreateProductCrawlRequest, Product>();
            CreateMap<CreateProductRequest, Product>();
            CreateMap<UpdateProductRequest, Product>();
            CreateMap<Product, ProductResponse>();
            CreateMap<PagedResponse<Product>, PagedResponse<ProductResponse>>();


            CreateMap<ProductPrice, ProductPriceResponse>();
            CreateMap<ProductReview, ProductReviewResponse>();
            CreateMap<ProductColor, ProductColorResponse>();
            CreateMap<ProductSize, ProductSizeResponse>();
        }
    }
}
