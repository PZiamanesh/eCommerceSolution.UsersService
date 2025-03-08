using AutoMapper;
using eCommerce.Core.Dtos;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Core.ServiceContracts;
using Mapster;

namespace eCommerce.Core.Services;

internal class UserService : IUserService
{
    private readonly IUserRepository userRepository;
    private readonly IMapper mapper;

    public UserService(
        IUserRepository userRepository,
        IMapper mapper
        )
    {
        this.userRepository = userRepository;
        this.mapper = mapper;
    }

    public async Task<UserDto> GetUserByUserID(Guid userID)
    {
        var appUser = await userRepository.GetUserByUserID(userID);
        var uerDto = mapper.Map<UserDto>(appUser);

        return uerDto;
    }

    public async Task<AuthenticationResponse?> Login(LoginRequest loginRequest)
    {
        var appUser = await userRepository.GetUserByEmailAndPassword(loginRequest.Email, loginRequest.Password);

        if (appUser == null)
        {
            return null;
        }

        return mapper.Map<AuthenticationResponse>(appUser) with { Token = "tok", Success = true };
    }

    public async Task<AuthenticationResponse?> Register(RegisterRequest registerRequest)
    {
        var newUser = mapper.Map<ApplicationUser>(registerRequest);

        var registredUser = await userRepository.AddUser(newUser);

        if (registredUser == null)
        {
            return null;
        }

        return mapper.Map<AuthenticationResponse>(newUser) with { Token = "tok", Success = true };
    }
}
