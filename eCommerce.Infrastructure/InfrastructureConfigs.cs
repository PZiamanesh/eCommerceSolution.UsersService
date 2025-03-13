using Microsoft.Extensions.DependencyInjection;
using UsersMicroService.Core.RepositoryContracts;
using UsersMicroService.Infrastructure.Repositories;

namespace UsersMicroService.Infrastructure;

public static class InfrastructureConfigs
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();

        services.AddScoped<DapperDbContext>();

        return services;
    }
}
