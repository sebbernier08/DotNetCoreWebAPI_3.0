using DotNetCoreWebAPI_3._0.Data.Models;

namespace DotNetCoreWebAPI_3._0.Data.Repositories.Impl
{
    public class BeerRepository : Repository<Beer>, IBeerRepository
    {
        private readonly ApiDbContext _context;

        public BeerRepository(ApiDbContext context): base(context)
        {
            _context = context;
        }
    }
}
