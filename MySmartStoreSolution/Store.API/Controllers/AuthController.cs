using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Application.DTO.User;
using Store.Application.Service;

namespace Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> Signup([FromBody] SignupRequestDTO request)
        {
            var result = await _authService.SignupAsync(request);

            if (result) return Ok(); // Return 200 OK if signup is successful

            return BadRequest();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateRequestDTO request)
        {
            // Call the appropriate service method to authenticate the user
            var user = await _authService.AuthenticateAsync(request);

            if (user == null)
                return Unauthorized(); // Return 401 Unauthorized if authentication fails

            // Generate a JWT token

            return new JsonResult(user);
        }
    }
}
