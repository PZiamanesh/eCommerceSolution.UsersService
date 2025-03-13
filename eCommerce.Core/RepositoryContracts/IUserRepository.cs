using UsersMicroService.Core.Entities;

namespace UsersMicroService.Core.RepositoryContracts;

public interface IUserRepository
{
    Task<ApplicationUser> AddUser(ApplicationUser user);

    Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password);

    Task<ApplicationUser?> GetUserByUserID(Guid? userID);
}
