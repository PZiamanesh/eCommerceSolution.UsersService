using UsersMicroService.Core.Dtos;

namespace UsersMicroService.Core.ServiceContracts;

public interface IUserService
{
    Task<AuthenticationResponse?> Login(LoginRequest loginRequest);

    Task<AuthenticationResponse?> Register(RegisterRequest registerRequest);

    Task<UserDto> GetUserByUserID(Guid userID);
}
