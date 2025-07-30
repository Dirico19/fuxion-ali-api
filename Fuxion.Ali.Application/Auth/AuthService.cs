using Fuxion.Ali.Application.Auth.Login;
using Fuxion.Ali.Application.Auth.Login.DTOs;
using Fuxion.Ali.Application.Common;
using Fuxion.Ali.Application.Security;
using Fuxion.Ali.Domain.Interfaces;

namespace Fuxion.Ali.Application.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtProvider _jwtProvider;
        private readonly IPasswordHasher _passwordHasher;

        public AuthService(IUnitOfWork unitOfWork, IJwtProvider jwtProvider, IPasswordHasher passwordHasher)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _jwtProvider = jwtProvider ?? throw new ArgumentNullException(nameof(jwtProvider));
            _passwordHasher = passwordHasher ?? throw new ArgumentNullException(nameof(passwordHasher));
        }

        public async Task<Result<LoginResponse>> LoginAsync(LoginRequest request, CancellationToken cancellationToken = default)
        {
            var user = await _unitOfWork.Users.GetByNameAsync(request.Username, cancellationToken);
            if (user is null)
            {
                return LoginResult.UserNotFound();
            }

            if (!_passwordHasher.Verify(request.Password, user.Password))
            {
                return LoginResult.InvalidPassword();
            }

            var token = _jwtProvider.GenerateToken(user);

            var response = new LoginResponse(token);

            return LoginResult.LoginSuccessful(response);
        }
    }
}
