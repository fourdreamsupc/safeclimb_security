using safeclimb_security.Security.Shared.Persistence.Contexts;

namespace safeclimb_security.Security.Shared.Persistence.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly AppDbContext _context;

        protected BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}