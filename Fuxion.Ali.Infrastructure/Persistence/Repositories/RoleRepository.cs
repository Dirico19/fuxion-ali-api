using Fuxion.Ali.Domain.Interfaces.Repositories;

namespace Fuxion.Ali.Infrastructure.Persistence.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        public Task<IEnumerable<T>> GetAllAsync<T>(CancellationToken cancellationToken = default) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
