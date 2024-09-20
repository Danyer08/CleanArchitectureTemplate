using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Data;
using Microsoft.Extensions.Configuration;

namespace Infrastructure;

public static class DependencyInjection {
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) {
        services.AddApplicationDbContextSetup(configuration.GetConnectionString("DefaultConnection") ?? throw new Exception("Connection string is empty"));
        services.AddRepositories();
        return services;
    }
}