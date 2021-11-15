using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Data.Configuration
{
    public static class DBConfiguration
    {
        public static IServiceCollection AddDataBaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
          
           

            return services;
        }
    }
}
