using Microsoft.AspNetCore.Mvc;
using RiraTask.Api.AutoMapper;
using RiraTask.Api.Controllers;
using RiraTask.Api.Middlewares;
using RiraTask.Core.Services;
using RiraTask.Core.Services.Interfaces;
using RiraTask.Infrastructure.Data;
using RiraTask.Infrastructure.Repositories;
using RiraTask.Infrastructure.Repositories.Interfaces;

namespace RiraTask.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        ConfigureMongoDb(builder);

        var app = builder.Build();

        ConfigurePipelines(app);

        app.MapGet("/", () =>
            "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

        app.Run();
    }

    private static void ConfigurePipelines(WebApplication app)
    {
        // Configure the HTTP request pipeline.
        app.MapGrpcService<GreeterController>();
    }

    private static void ConfigureMongoDb(WebApplicationBuilder builder)
    {
        // Configure MongoDB settings
        builder.Services.Configure<MongoDbSettings>(
            builder.Configuration.GetSection(nameof(MongoDbSettings)));

        // Register MongoDB context as a singleton
        builder.Services.AddSingleton<MongoDbContext>();
    }
}