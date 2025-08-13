using Fuxion.Ali.Contracts.Auth.Login;
using Fuxion.Ali.Contracts.Common;

namespace Fuxion.Ali.Application.Auth.Login
{
    public static class LoginResult
    {
        public static Result<LoginResponse> UserNotFound()
        {
            return Result<LoginResponse>.Fail(401, "USER_NOT_FOUND", "Usuario no encontrado.");
        }

        public static Result<LoginResponse> InvalidPassword()
        {
            return Result<LoginResponse>.Fail(401, "INVALID_PASSWORD", "Contraseña incorrecta.");
        }

        public static Result<LoginResponse> LoginSuccessful(LoginResponse response)
        {
            return Result<LoginResponse>.Ok(response, "Inicio de sesión exitoso.");
        }
    }
}
