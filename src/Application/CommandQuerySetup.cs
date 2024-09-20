using Microsoft.Extensions.DependencyInjection;
using Application.Product.Queries;
using Application.User.Commands;
using Application.Product.Commands.CreateProduct;

namespace Application;

public static class CommandQuerySetup {
    public static IServiceCollection AddCommands(this IServiceCollection services) {
        services.AddScoped<LoginCommand>();
        services.AddScoped<RegisterCommand>();
        return services;
    }

    public static IServiceCollection AddQueries(this IServiceCollection services) {
        services.AddScoped<GetProductQueryHandler>();
        services.AddScoped<CreateProductCommandHandler>();
        return services;
    }
}