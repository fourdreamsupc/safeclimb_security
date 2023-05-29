using safeclimb_security.Security.Shared.Domain.Repositories;
using safeclimb_security.Security.Shared.Persistence.Contexts;

namespace safeclimb_security.Security.Shared.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}