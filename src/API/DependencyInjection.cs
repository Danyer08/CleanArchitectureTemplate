using Microsoft.OpenApi.Models;

namespace API;

public static class DependencyInjection {
    public static IServiceCollection AddAPI(this IServiceCollection services) {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options => options.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "Clean Architecture API",
            Version = "v1",
            Description = "A simple example of Clean Architecture API",
            Contact = new OpenApiContact
            {
                Name = "Danyer Dominguez",
                Email = "danyer.dominguez.dev@gmail.com"
            }
        }));
        return services;
    }
}