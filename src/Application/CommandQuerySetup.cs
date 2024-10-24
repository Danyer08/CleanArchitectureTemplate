using Microsoft.Extensions.DependencyInjection;
using Application.Product.Queries;
using Application.User.Commands;
using Application.Product.Commands.CreateProduct;
using Application.Common;

namespace Application;

public static class CommandQuerySetup
{
    public static IServiceCollection AddCommands(this IServiceCollection services)
    {
        services.AddScoped<LoginCommand>();
        services.AddScoped<RegisterCommand>();
        services.AddScoped<CommandHandler>();
        return services;
    }

    public static IServiceCollection AddQueries(this IServiceCollection services)
    {
        services.AddScoped<GetProductQueryHandler>();
        services.AddScoped<CreateProductCommandHandler>();
        services.AddScoped<QueryHandler>();
        return services;
    }
}