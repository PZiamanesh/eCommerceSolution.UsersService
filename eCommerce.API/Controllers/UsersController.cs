using eCommerce.Core.Dtos;
using eCommerce.Core.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers;

[ApiController]
[Route("api/users/")]
public class UsersController : ControllerBase
{
    private readonly IUserService userService;

    public UsersController(IUserService userService)
    {
        this.userService = userService;
    }

    [HttpGet("{userId}")]
    public async Task<ActionResult<UserDto>> GetUserByUserId(Guid userId)
    {
        return await userService.GetUserByUserID(userId);
    }
}
