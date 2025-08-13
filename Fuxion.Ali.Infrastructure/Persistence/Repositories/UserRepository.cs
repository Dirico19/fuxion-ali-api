using Fuxion.Ali.Domain.Entities;
using Fuxion.Ali.Domain.Interfaces.Repositories;
using Fuxion.Ali.Infrastructure.Persistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Fuxion.Ali.Infrastructure.Persistence.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<User?> GetByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            return await _context.Users.AsNoTracking().Include(u => u.UserRoles).ThenInclude(ur => ur.Role).SingleOrDefaultAsync(u => u.Name == name, cancellationToken);
        }

        public async Task<User?> FindWithDetailsByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Users
                .Include(u => u.UserRoles).ThenInclude(ur => ur.Role)
                .Include(u => u.Contacts)
                .SingleOrDefaultAsync(u => u.Id == id, cancellationToken);
        }

        public async Task<IEnumerable<User>> GetAllWithDetailsByUpdatedAtAfterAsync(DateTime updatedAt, CancellationToken cancellationToken = default)
        {
            return await _context.Users
                .Include(u => u.UserRoles).ThenInclude(ur => ur.Role)
                .Include(u => u.Contacts)
                .Where(u => u.UpdatedAt > updatedAt)
                .ToListAsync(cancellationToken);
        }
    }
}
