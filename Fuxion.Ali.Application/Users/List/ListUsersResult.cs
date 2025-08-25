using Fuxion.Ali.Contracts.Common;
using Fuxion.Ali.Contracts.Users.List;

namespace Fuxion.Ali.Application.Users.List
{
    public static class ListUsersResult
    {
        public static Result<ListUsersResponse> NoUsersFound()
        {
            return Result<ListUsersResponse>.Fail(404, "NO_USERS_FOUND", "No se encontraron usuarios.");
        }

        public static Result<ListUsersResponse> UsersFound(ListUsersResponse response)
        {
            return Result<ListUsersResponse>.Ok(response, "Usuarios encontrados.");
        }
    }
}
