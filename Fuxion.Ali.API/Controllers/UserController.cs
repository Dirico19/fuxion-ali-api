using Fuxion.Ali.Application.Users;
using Fuxion.Ali.Contracts.Users.Get;
using Fuxion.Ali.Contracts.Users.List;
using Microsoft.AspNetCore.Mvc;

namespace Fuxion.Ali.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers([FromQuery] ListUsersRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _userService.ListUsersAsync(request, cancellationToken);

            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetUser([FromRoute] GetUserRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _userService.GetUserAsync(request, cancellationToken);

            return StatusCode(result.StatusCode, result);
        }
    }
}
