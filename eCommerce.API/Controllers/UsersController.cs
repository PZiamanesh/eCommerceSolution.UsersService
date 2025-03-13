using UsersMicroService.Core.Dtos;
using UsersMicroService.Core.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace UsersMicroService.API.Controllers;

[ApiController]
[Route("api/users/")]
public class UsersController : ControllerBase
{
    private readonly IUserService userService;

    public UsersController(IUserService userService)
    {
        this.userService = userService;
    }

    [HttpGet("{userID}")]
    public async Task<ActionResult<UserDto>> GetUserByUserId(Guid userID)
    {
        return await userService.GetUserByUserID(userID);
    }
}
