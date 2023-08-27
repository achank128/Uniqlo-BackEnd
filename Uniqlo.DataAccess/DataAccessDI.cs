using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.DataAccess.Repositories.CategoryRepository;
using Uniqlo.DataAccess.Repositories.CouponRepository;
using Uniqlo.DataAccess.RepositoryBase;
using Uniqlo.Models.Context;

namespace Uniqlo.DataAccess
{
    public static class DataAccessDI
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDatabase(configuration);

            services.AddRepositories();

            return services;
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICouponRepository, CouponRepository>();
        }

        private static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<UniqloContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
        }

    }
}

