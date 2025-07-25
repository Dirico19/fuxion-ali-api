using Fuxion.Ali.Domain.Entities;
using Fuxion.Ali.Domain.Interfaces.Repositories;
using Fuxion.Ali.Infrastructure.Persistence.Repositories.Base;

namespace Fuxion.Ali.Infrastructure.Persistence.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public Task<User?> GetByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
