using Fuxion.Ali.Domain.Entities;

namespace Fuxion.Ali.Application.Security
{
    public interface IJwtProvider
    {
        string GenerateToken(User user);
    }
}
