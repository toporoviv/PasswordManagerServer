using DAL.Implementations.PasswordManagerRepositories;
using Domain.Repositories.EmailPasswordManagerRepositories;
using Domain.Repositories.SitePasswordManagerRepositories;
using Microsoft.Extensions.DependencyInjection;

namespace DAL.Extensions.ServiceCollectionExtensions;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IEmailPasswordManagerRepository, EmailPasswordManagerRepository>();
        services.AddScoped<ISitePasswordManagerRepository, SitePasswordManagerRepository>();

        return services;
    }
}
