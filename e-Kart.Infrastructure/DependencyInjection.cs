using e_Kart.Core.RepositoryContracts;
using e_Kart.Infrastructure.ApplicationDbContext;
using e_Kart.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace e_Kart.Infrastructure;
public static class DependencyInjection
{
    /// <summary>
    /// Extension method to add infrastructure service to dependency injection container
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<DbContext>();
        return services;
    }
}
