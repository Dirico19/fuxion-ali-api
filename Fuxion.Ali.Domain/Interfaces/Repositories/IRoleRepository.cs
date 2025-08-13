using Fuxion.Ali.Domain.Entities;

namespace Fuxion.Ali.Domain.Interfaces.Repositories
{
    public interface IRoleRepository
    {
        Task<IEnumerable<Role>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}
