using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using UsersMicroService.Core.ServiceContracts;
using UsersMicroService.Core.Services;

namespace UsersMicroService.Core;

public static class CoreConfigs
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();

        services.AddValidatorsFromAssembly(typeof(CoreConfigs).Assembly);

        return services;
    }
}
