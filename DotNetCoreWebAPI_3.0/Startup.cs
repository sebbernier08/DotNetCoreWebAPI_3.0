using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DotNetCoreWebAPI_3._0.Data;
using DotNetCoreWebAPI_3._0.Data.Repositories;
using DotNetCoreWebAPI_3._0.Data.Repositories.Impl;
using DotNetCoreWebAPI_3._0.Mappers;
using DotNetCoreWebAPI_3._0.Services;
using DotNetCoreWebAPI_3._0.Services.Impl;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DotNetCoreWebAPI_3._0
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Add All Database Context
            services.AddDbContext<ApiDbContext>(opt => opt.UseInMemoryDatabase("ApiDatabase"));

            // Add Repositories DI
            services.AddTransient<IBeerRepository, BeerRepository>();

            // Add Services DI
            services.AddTransient<IBeerService, BeerService>();

            // Configuration for AutoMapper
            // ==========================================================
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapperProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            // ==========================================================
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
