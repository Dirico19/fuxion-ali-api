using Fuxion.Ali.Contracts.Auth.Login;
using Fuxion.Ali.Contracts.Common;

namespace Fuxion.Ali.Application.Auth
{
    public interface IAuthService
    {
        Task<Result<LoginResponse>> LoginAsync(LoginRequest request, CancellationToken cancellationToken = default);
    }
}
