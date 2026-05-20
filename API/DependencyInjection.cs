using System.Text.Json.Serialization;
using API.Exceptions;
using Application.Common.Behaviors;
using Application.Common.Interfaces;
using FluentValidation;
using Infrastructure.Data;
using Infrastructure.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API;


public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCustomProblemDetails()
                .AddApiDocumentation()
                .AddExceptionHandling()
                .AddControllerWithJsonConfiguration()
                .AddMediatR()
                .AddValidatorsFromAssembly()
                .AddValidationBehavior()
                .AddDatabase(configuration)
                .AddAppDbContext()
                .AddLocalFileStorageService();

        return services;
    }

    public static IServiceCollection AddCustomProblemDetails(this IServiceCollection services)
    {
        services.AddProblemDetails();
        return services;
    }

    public static IServiceCollection AddApiDocumentation(this IServiceCollection services)
    {
        services.AddOpenApi();
        return services;
    }

        public static IServiceCollection AddExceptionHandling(this IServiceCollection services)
    {
        services.AddExceptionHandler<GlobalExceptionHandler>();
        return services;
    }

    public static IServiceCollection AddControllerWithJsonConfiguration(this IServiceCollection services)
    {
        services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        });
        return services;
    }

    
    public static IServiceCollection AddMediatR(this IServiceCollection services)
    {
        services.AddMediatR(Options => Options.RegisterServicesFromAssembly(typeof(Application.IAssemblyMarker).Assembly));
        return services;
    }
    
    public static IServiceCollection AddValidatorsFromAssembly(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(typeof(Application.IAssemblyMarker).Assembly);
        return services;
    }

    public static IServiceCollection AddValidationBehavior(this IServiceCollection services)
    {
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        return services;
    }

    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection") ?? "Data Source=app.db";

        services.AddDbContext<AppDbContext>(options => options.UseSqlite(connectionString));
        return services;
    }
        
        
    public static IServiceCollection AddAppDbContext(this IServiceCollection services)
    {
        services.AddScoped<IAppDbContext, AppDbContext>();
        return services;
    }
        
    public static IServiceCollection AddLocalFileStorageService(this IServiceCollection services)
    {
        services.AddScoped<IFileStorageService, LocalFileStorageService>();
        return services;
    }
}