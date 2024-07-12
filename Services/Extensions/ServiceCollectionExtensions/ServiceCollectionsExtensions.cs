using Domain.Services.EmailPasswordManagerServices;
using Domain.Services.SitePasswordManagerServices;
using Microsoft.Extensions.DependencyInjection;
using Services.Implementations.EmailPasswordManagerServices;
using Services.Implementations.SitePasswordManagerServices;

namespace Services.Extensions.ServiceCollectionExtensions;
public static class ServiceCollectionsExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IEmailPasswordManagerService, EmailPasswordManagerService>();
        services.AddScoped<ISitePasswordManagerService, SitePasswordManagerServices>();

        return services;
    }
}
