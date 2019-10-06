using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreWebAPI_3._0.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DotNetCoreWebAPI_3._0
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<ApiDbContext>();

                AddTestData(context);
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static void AddTestData(ApiDbContext context)
        {
            context.Beers.AddRange(
                new Data.Models.Beer()
                {
                    Id = 1,
                    Name = "Nuit Blanche",
                    Type = Data.Models.BeerType.API
                },
                new Data.Models.Beer()
                {
                    Id = 2,
                    Name = "Chipie",
                    Type = Data.Models.BeerType.RED
                }
            );

            context.Users.Add(
               new Data.Models.User()
               {
                   Id = 1,
                   FirstName = "Sébastien",
                   LastName = "Bernier",
                   Email = "sebbernier@effenti.ca",
                   Password = "asd",
                   Role = Data.Models.Role.ADMIN
               }
           );

            context.SaveChanges();
        }
    }
}

