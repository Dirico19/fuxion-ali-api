using Fuxion.Ali.Domain.Entities;
using Fuxion.Ali.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Fuxion.Ali.Infrastructure.Persistence.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly AppDbContext _context;

        public RoleRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Role>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Roles.AsNoTracking().ToListAsync(cancellationToken);
        }
    }
}
