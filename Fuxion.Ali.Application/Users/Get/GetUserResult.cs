using Fuxion.Ali.Contracts.Common;
using Fuxion.Ali.Contracts.Users.Get;

namespace Fuxion.Ali.Application.Users.Get
{
    public static class GetUserResult
    {
        public static Result<GetUserResponse> UserFound(GetUserResponse response)
        {
            return Result<GetUserResponse>.Ok(response, "Usuario encontrado.");
        }

        public static Result<GetUserResponse> UserNotFound()
        {
            return Result<GetUserResponse>.Fail(404, "USER_NOT_FOUND", "Usuario no encontrado.");
        }
    }
}
