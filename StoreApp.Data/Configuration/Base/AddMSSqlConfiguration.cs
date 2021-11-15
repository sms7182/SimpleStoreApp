using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Data.Configuration.Base
{
    public static class AddMSSqlConfiguration
    {
        public static IServiceCollection AddSqlWrite<T>(this IServiceCollection services, IConfiguration configuration) where T : DbContext
        {
            services.AddEntityFrameworkSqlServer().AddDbContext<T>(options =>
            {
                options.UseSqlServer(configuration["messageDBConnection"], d => d.MigrationsAssembly(typeof(T).Assembly.GetName().Name));
            });

            return services;

        }

        public static IServiceCollection AddSqlRead<T>(this IServiceCollection services, IConfiguration configuration) where T : DbContext
        {
            services.AddEntityFrameworkSqlServer().AddDbContext<T>(options =>
            {
                options.UseSqlServer(configuration["readmessageDBConnection"], d => d.MigrationsAssembly(typeof(T).Assembly.GetName().Name));
            });

            return services;

        }
    }
}
