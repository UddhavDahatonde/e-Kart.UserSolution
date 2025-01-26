using e_Kart.Core.DTO;
using e_Kart.Core.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace e_Kart.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest? loginRequest)
        {
            if (loginRequest is null)
            {
                return BadRequest("Invalid login data");
            }
            AuthenticationResponse? authenticationResponse = await _userService.Login(loginRequest);

            if (authenticationResponse is null || authenticationResponse.Success == false)
            {
                return Unauthorized(authenticationResponse);
            }
            return Ok(authenticationResponse);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest? registerRequest)
        {
            if (registerRequest is null)
            {
                return BadRequest("Invalid Registration Data");
            }

            AuthenticationResponse? authenticationResponse = await _userService.Registration(registerRequest);
            if (authenticationResponse is null || authenticationResponse.Success.Equals(false))
            {
                return BadRequest(authenticationResponse);
            }
            return Ok(authenticationResponse);
        }
    }
}
