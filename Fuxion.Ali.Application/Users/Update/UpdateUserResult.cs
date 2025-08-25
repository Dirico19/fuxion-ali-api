using Fuxion.Ali.Contracts.Common;
using Fuxion.Ali.Contracts.Users.Update;

namespace Fuxion.Ali.Application.Users.Update
{
    public class UpdateUserResult
    {
        public static Result<UpdateUserResponse> UserUpdated()
        {
            return Result<UpdateUserResponse>.Ok(null, "Usuario guardado.");
        }

        public static Result<UpdateUserResponse> UserNotFound()
        {
            return Result<UpdateUserResponse>.Fail(404, "USER_NOT_FOUND", "Usuario no encontrado.");
        }

        public static Result<UpdateUserResponse> UserContactNotFound()
        {
            return Result<UpdateUserResponse>.Fail(404, "CONTACT_NOT_FOUND", "Contacto no encontrado.");
        }
    }
}
