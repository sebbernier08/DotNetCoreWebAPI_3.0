using DotNetCoreWebAPI_3._0.Data.Models;

namespace DotNetCoreWebAPI_3._0.Data.Repositories.Impl
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly ApiDbContext _context;

        public UserRepository(ApiDbContext context): base(context)
        {
            _context = context;
        }
    }
}
