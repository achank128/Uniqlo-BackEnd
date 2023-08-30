using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.BusinessLogic.Services.AuthService;
using Uniqlo.BusinessLogic.Services.CartItemService;
using Uniqlo.BusinessLogic.Services.CartService;
using Uniqlo.BusinessLogic.Services.CategoryService;
using Uniqlo.BusinessLogic.Services.CollectionService;
using Uniqlo.BusinessLogic.Services.ColorService;
using Uniqlo.BusinessLogic.Services.CouponService;
using Uniqlo.BusinessLogic.Services.GenderTypeService;
using Uniqlo.BusinessLogic.Services.OderItemService;
using Uniqlo.BusinessLogic.Services.OrderService;
using Uniqlo.BusinessLogic.Services.PaymentService;
using Uniqlo.BusinessLogic.Services.ProductDetailService;
using Uniqlo.BusinessLogic.Services.ProductService;
using Uniqlo.BusinessLogic.Services.RegionService;
using Uniqlo.BusinessLogic.Services.ShipmentService;
using Uniqlo.BusinessLogic.Services.SizeService;
using Uniqlo.BusinessLogic.Services.UnitService;
using Uniqlo.BusinessLogic.Services.UserAddressService;
using Uniqlo.BusinessLogic.Services.UserCouponService;
using Uniqlo.BusinessLogic.Services.UserService;
using Uniqlo.BusinessLogic.Services.WishListService;
using Uniqlo.BusinessLogic.Shared.ClaimService;

namespace Uniqlo.BusinessLogic
{
    public static class BusinessLogicDI
    {
        public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
        {
            services.AddServices();

            services.RegisterAutoMapper();

            return services;
        }

        private static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IClaimService, ClaimService>();
            services.AddScoped<IUnitService, UnitService>();
            services.AddScoped<ICollectionService, CollectionService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IGenderTypeService, GenderTypeService>();
            services.AddScoped<ISizeService, SizeService>();
            services.AddScoped<IColorService, ColorService>();
            services.AddScoped<ICouponService, CouponService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductDetailService, ProductDetailService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserCouponService, UserCouponService>();
            services.AddScoped<IWishListService, WishListService>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<ICartItemService, CartItemService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderItemService, OrderItemService>();
            services.AddScoped<IShipmentService, ShipmentService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IUserAddressService, UserAddressService>();
            services.AddScoped<IRegionService, RegionService>();
        }

        private static void RegisterAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }


    }
}
