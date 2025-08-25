using Fuxion.Ali.Contracts.Common;
using Fuxion.Ali.Contracts.Users.Create;

namespace Fuxion.Ali.Application.Users.Create
{
    public static class CreateUserResult
    {
        public static Result<CreateUserResponse> UserCreated()
        {
            return Result<CreateUserResponse>.Ok(null, "Usuario guardado.");
        }

        public static Result<CreateUserResponse> UserAlreadyExists()
        {
            return Result<CreateUserResponse>.Fail(400, "USER_ALREADY_EXISTS", "El usuario ya existe.");
        }
    }
}
