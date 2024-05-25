using HashNode.API.Shared.Infrastructure.Persistence.Data;

namespace HashNode.API.Shared.Infrastructure.Persistence.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

    }

}
