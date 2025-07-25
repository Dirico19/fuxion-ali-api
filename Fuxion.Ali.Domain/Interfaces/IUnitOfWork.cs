using Fuxion.Ali.Domain.Interfaces.Repositories;

namespace Fuxion.Ali.Domain.Interfaces
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        IUserRepository Users { get; }
        IRoleRepository Roles { get; }
    }
}
