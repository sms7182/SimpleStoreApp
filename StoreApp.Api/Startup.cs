using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using StoreApp.ApplicationService.CommandQueryHandlers.Items.ServiceBuilder;
using StoreApp.ApplicationService.CommandQueryHandlers.Orders.ServiceBuilder;
using StoreApp.ApplicationService.CommandQueryHandlers.ServiceBuilder;
using StoreApp.ApplicationService.Configurations;
using StoreApp.Data.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public string mypolicy = "mypolicy";
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();


            services.AddDataBaseConfiguration(Configuration);
          
            services.AddScoped<ICreateItemService, CreateItemService>();
            services.AddScoped<ICreateOrderService, CreateOrderService>();
            services.AddScoped<IUpdateItemService, UpdateItemService>();
            services.AddScoped<ISendOrderService, SendBreakableOrderService>();
            services.AddScoped<ISendOrderService, SendNormalOrderService>();
            services.AddScoped<ISendOrderServiceBuilder, SendOrderServiceBudiler>();

            services.AddApplicationServices(Configuration);
            services.AddCors(options =>
            {
                options.AddPolicy(mypolicy,builder => builder.WithOrigins("http://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials()
                    .SetIsOriginAllowed((host) => true));
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "StoreApp.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "StoreApp.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(mypolicy);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
