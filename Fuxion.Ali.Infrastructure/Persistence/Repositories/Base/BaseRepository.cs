using Fuxion.Ali.Domain.Entities.Base;
using Fuxion.Ali.Domain.Interfaces.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Fuxion.Ali.Infrastructure.Persistence.Repositories.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _context.Set<T>().AddAsync(entity, cancellationToken);
        }

        public Task Delete(T entity, CancellationToken cancellationToken = default)
        {
            _context.Set<T>().Remove(entity);

            return Task.CompletedTask;
        }

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Set<T>().ToListAsync(cancellationToken);
        }

        public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Set<T>().FindAsync([id], cancellationToken);
        }

        public Task SoftDelete(BaseEntity entity, CancellationToken cancellationToken = default)
        {
            entity.IsDeleted = true;
            entity.DeletedAt = DateTime.UtcNow;

            return Task.CompletedTask;
        }

        public Task Update(T entity, CancellationToken cancellationToken = default)
        {
            _context.Set<T>().Update(entity);

            return Task.CompletedTask;
        }
    }
}
