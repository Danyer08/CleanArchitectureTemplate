using Microsoft.Extensions.DependencyInjection;
using Application.Product.Interfaces;
using Application.User.Interfaces;
using Infrastructure.Data.User;
using Infrastructure.Data.Product;

namespace Infrastructure.Data;

public static class RepositoriesSetup
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();

        return services;
    }
}

