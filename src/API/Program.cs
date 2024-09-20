using Infrastructure;
using Application;
using API;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddAPI()
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Clean Architecture API V1");
        c.RoutePrefix = "swagger";
    });
}

app.UseRouting();
app.MapControllers();

app.Run();