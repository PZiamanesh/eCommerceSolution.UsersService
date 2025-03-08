using Dapper;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;

namespace eCommerce.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DapperDbContext dbContext;

    public UserRepository(DapperDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<ApplicationUser> AddUser(ApplicationUser user)
    {
        user.UserID = Guid.NewGuid();
        string query = @"
        INSERT INTO public.""Users"" (
            ""UserID"",
            ""Email"",
            ""Password"",
            ""PersonName"",
            ""Gender""
        )
        VALUES (
            @UserID,
            @Email,
            @Password,
            @PersonName,
            @Gender
        )";

        int rowCount = await dbContext.DbConnection.ExecuteAsync(query, user);

        return user;
    }

    public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
    {
        var query = @"
        select * from public.""Users"" where ""Email""=@Email and ""Password""=@Password
        ";

        var user = await dbContext.DbConnection.QueryFirstAsync<ApplicationUser>(query, new {Email = email, Password = password});

        if (user is null)
        {
            return null;
        }

        return user;
    }

    public async Task<ApplicationUser?> GetUserByUserID(Guid? userID)
    {
        var query = @"
            select * from public.""Users"" where ""UserID""=@UserID
        ";

        var user = await dbContext.DbConnection.QueryFirstAsync<ApplicationUser>(query, new { UserID = userID });

        if (user is null)
        {
            return null;
        }

        return user;
    }
}
