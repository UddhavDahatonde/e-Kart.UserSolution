using e_Kart.Core.ServiceContracts;
using e_Kart.Core.Services;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
namespace e_Kart.Core;
public static class DependencyInjection
{
    /// <summary>
    /// Extension method to add infrastructure service to dependency injection container
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();
        return services;
    }
}
