using DotNetCoreWebAPI_3._0.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreWebAPI_3._0.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Beer> Beers { get; set; }
    }
}
