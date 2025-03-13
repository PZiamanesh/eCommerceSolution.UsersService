using Microsoft.AspNetCore.Mvc;
using UsersMicroService.Core.Dtos;
using UsersMicroService.Core.ServiceContracts;

namespace UsersMicroService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;

    public AuthController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest registerRequestDto)
    {
        if (registerRequestDto == null)
        {
            return BadRequest("Invalid registration data");
        }

        var authResponse = await _userService.Register(registerRequestDto);

        if (authResponse == null || authResponse.Success == false)
        {
            return BadRequest(authResponse);
        }

        return Ok(authResponse);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest loginRequest)
    {
        if (loginRequest == null)
        {
            return BadRequest("Invalid login data");
        }

        var authResponse = await _userService.Login(loginRequest);

        if (authResponse == null || authResponse.Success == false)
        {
            return Unauthorized(authResponse);
        }

        return Ok(authResponse);
    }
}
