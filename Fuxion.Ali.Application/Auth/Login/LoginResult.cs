using Fuxion.Ali.Application.Common;
using Fuxion.Ali.Contracts.Auth.Login;

namespace Fuxion.Ali.Application.Auth.Login
{
    public static class LoginResult
    {
        public static Result<LoginResponse> UserNotFound()
        {
            return Result<LoginResponse>.Fail(401, "USER_NOT_FOUND", "User not found");
        }

        public static Result<LoginResponse> InvalidPassword()
        {
            return Result<LoginResponse>.Fail(401, "INVALID_PASSWORD", "Invalid password");
        }

        public static Result<LoginResponse> LoginSuccessful(LoginResponse response)
        {
            return Result<LoginResponse>.Ok(response, "Login successful");
        }
    }
}
