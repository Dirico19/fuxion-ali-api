using Fuxion.Ali.Application.Auth;
using Fuxion.Ali.Contracts.Auth.Login;
using Microsoft.AspNetCore.Mvc;

namespace Fuxion.Ali.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IAuthService _authService;

        public AuthController(ILogger<AuthController> logger, IAuthService authService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request, CancellationToken cancellationToken = default)
        {
            if (request is null || string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
            {
                return BadRequest("Por favor, ingrese los campos obligatorios.");
            }

            var result = await _authService.LoginAsync(request, cancellationToken);
            if (!result.IsSuccess)
            {
                return result.StatusCode switch
                {
                    401 => Unauthorized(result),
                    _ => StatusCode(StatusCodes.Status500InternalServerError, result)
                };
            }
            
            return Ok(result);
        }
    }
}
