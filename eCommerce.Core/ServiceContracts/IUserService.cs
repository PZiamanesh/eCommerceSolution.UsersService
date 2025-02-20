using eCommerce.Core.Dtos;

namespace eCommerce.Core.ServiceContracts;

public interface IUserService
{
    Task<AuthenticationResponse?> Login(LoginRequest loginRequest);
    Task<AuthenticationResponse?> Register(RegisterRequest registerRequest);
}
