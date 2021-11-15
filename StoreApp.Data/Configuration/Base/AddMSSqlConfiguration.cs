using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Data.Configuration.Base
{
    public static class AddPostgresSqlConfiguration
    {
        public static IServiceCollection AddPostgresWrite<T>(this IServiceCollection services, IConfiguration configuration) where T : DbContext
        {
            services.AddEntityFrameworkNpgsql().AddDbContext<T>(options =>
            {
                options.UseNpgsql(configuration["storeDBConnection"], d => d.MigrationsAssembly(typeof(T).Assembly.GetName().Name));
            });

            return services;

        }

       
    }
}
