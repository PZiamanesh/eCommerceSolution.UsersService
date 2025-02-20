using eCommerce.Core.ServiceContracts;
using eCommerce.Core.Services;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Core;

public static class CoreConfigs
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();

        services.AddValidatorsFromAssembly(typeof(CoreConfigs).Assembly);

        return services;
    }
}
