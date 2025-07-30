using Fuxion.Ali.Application.Auth.Login.DTOs;
using Fuxion.Ali.Application.Common;

namespace Fuxion.Ali.Application.Auth
{
    public interface IAuthService
    {
        Task<Result<LoginResponse>> LoginAsync(LoginRequest request, CancellationToken cancellationToken = default);
    }
}
