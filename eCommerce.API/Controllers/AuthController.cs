using eCommerce.Core.Dtos;
using eCommerce.Core.ServiceContracts;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using LoginRequest = eCommerce.Core.Dtos.LoginRequest;
using RegisterRequest = eCommerce.Core.Dtos.RegisterRequest;

namespace eCommerce.API.Controllers;

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
    public async Task<IActionResult> Register(RegisterRequest registerRequest)
    {
        if (registerRequest == null)
        {
            return BadRequest("Invalid registration data");
        }

        var authResponse = await _userService.Register(registerRequest);

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
