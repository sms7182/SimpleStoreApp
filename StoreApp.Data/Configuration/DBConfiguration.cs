using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StoreApp.Data.Configuration.Base;
using StoreApp.Data.UnitOfWorks;
using StoreApp.Domain.IDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Data.Configuration
{
    public static class DBConfiguration
    {
        public static IServiceCollection AddDataBaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddPostgresWrite<StoreDBContext>(configuration);
        
            services.AddScoped<IStoreUnitOfWork, StoreUnitOfWork>();



            return services;
        }
    }
}
