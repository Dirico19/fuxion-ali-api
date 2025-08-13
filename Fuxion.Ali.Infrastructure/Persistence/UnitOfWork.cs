using Fuxion.Ali.Domain.Entities.Base;
using Fuxion.Ali.Domain.Interfaces;
using Fuxion.Ali.Domain.Interfaces.Repositories;
using Fuxion.Ali.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Fuxion.Ali.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private IUserRepository? _users;
        private IRoleRepository? _roles;

        public UnitOfWork(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IUserRepository Users => _users ??= new UserRepository(_context);

        public IRoleRepository Roles => _roles ??= new RoleRepository(_context);

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in _context.ChangeTracker.Entries<BaseEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                }
            }

            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
