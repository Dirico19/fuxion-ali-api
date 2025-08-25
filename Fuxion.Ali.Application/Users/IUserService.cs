using Fuxion.Ali.Contracts.Common;
using Fuxion.Ali.Contracts.Users.Create;
using Fuxion.Ali.Contracts.Users.Get;
using Fuxion.Ali.Contracts.Users.List;
using Fuxion.Ali.Contracts.Users.Update;

namespace Fuxion.Ali.Application.Users
{
    public interface IUserService
    {
        Task<Result<ListUsersResponse>> ListUsersAsync(ListUsersRequest request, CancellationToken cancellationToken = default);
        Task<Result<GetUserResponse>> GetUserAsync(GetUserRequest request, CancellationToken cancellationToken = default);
        Task<Result<UpdateUserResponse>> UpdateUserAsync(UpdateUserRequest request, CancellationToken cancellationToken = default);
        Task<Result<CreateUserResponse>> CreateUserAsync(CreateUserRequest request, CancellationToken cancellationToken = default);
    }
}
