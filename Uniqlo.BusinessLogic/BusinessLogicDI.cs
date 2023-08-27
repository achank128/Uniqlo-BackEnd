using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.BusinessLogic.Services.Implements;
using Uniqlo.BusinessLogic.Services.Interfaces;

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
            services.AddScoped<IUnitsService, UnitsService>();
            services.AddScoped<ICollectionsService, CollectionsService>();
        }

        private static void RegisterAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }


    }
}
