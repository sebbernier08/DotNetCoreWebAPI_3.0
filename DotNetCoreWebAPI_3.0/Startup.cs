using AutoMapper;
using DotNetCoreWebAPI_3._0.Data;
using DotNetCoreWebAPI_3._0.Data.Repositories;
using DotNetCoreWebAPI_3._0.Data.Repositories.Impl;
using DotNetCoreWebAPI_3._0.Mappers;
using DotNetCoreWebAPI_3._0.Services;
using DotNetCoreWebAPI_3._0.Services.Impl;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

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
            // Add Jwt Authentication
            //===========================================================================//
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"])),
                    ClockSkew = TimeSpan.Zero
                };
            });
            //===========================================================================//

            // Add Cors (Cross-origin resource sharing) 
            // Source : https://developer.mozilla.org/fr/docs/Web/HTTP/CORS
            //===========================================================================//
            services.AddCors();
            services.AddCors(options => {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
            //===========================================================================//

            services.AddControllers();

            // Add All Database Context
            services.AddDbContext<ApiDbContext>(opt => opt.UseInMemoryDatabase("ApiDatabase"));

            // Add Repositories DI
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IBeerRepository, BeerRepository>();

            // Add Services DI
            services.AddTransient<IAuthService, AuthService>();
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
