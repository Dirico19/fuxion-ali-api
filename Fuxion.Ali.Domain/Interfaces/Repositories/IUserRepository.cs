using Fuxion.Ali.Domain.Entities;
using Fuxion.Ali.Domain.Interfaces.Repositories.Base;

namespace Fuxion.Ali.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User?> GetByNameAsync(string name, CancellationToken cancellationToken = default);
        Task<User?> FindWithDetailsByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<User>> GetAllFilteredAsync(string? search, CancellationToken cancellationToken = default);
    }
}
