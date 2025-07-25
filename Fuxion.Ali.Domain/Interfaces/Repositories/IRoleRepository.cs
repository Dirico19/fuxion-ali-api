namespace Fuxion.Ali.Domain.Interfaces.Repositories
{
    public interface IRoleRepository
    {
        Task<IEnumerable<T>> GetAllAsync<T>(CancellationToken cancellationToken = default) where T : class;
    }
}
