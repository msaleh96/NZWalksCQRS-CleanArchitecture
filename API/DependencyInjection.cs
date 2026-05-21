using System.Text.Json.Serialization;
using API.Exceptions;
using Application.Common.Behaviors;
using Application.Common.Interfaces;
using Application.Infrastructure.Identity;
using FluentValidation;
using Infrastructure.Data;
using Infrastructure.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;

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
                .AddPipelineBehaviors()
                .AddDatabase(configuration)
                .AddAppDbContext()
                .AddLocalFileStorageService()
                .AddIdentityServices()
                .AddTokenProvider();

        return services;
    }

    public static IServiceCollection AddCustomProblemDetails(this IServiceCollection services)
    {
        services.AddProblemDetails();
        return services;
    }

    public static IServiceCollection AddApiDocumentation(this IServiceCollection services)
    {
        services.AddOpenApi(options =>
        {
            options.AddDocumentTransformer((document, context, cancellationToken) =>
            {
                document.Components ??= new OpenApiComponents();
                document.Components.SecuritySchemes ??= new Dictionary<string, IOpenApiSecurityScheme>();
                document.Components.SecuritySchemes["Bearer"] = new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter your JWT Bearer token."
                };
                return Task.CompletedTask;
            });
        });

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

    public static IServiceCollection AddPipelineBehaviors(this IServiceCollection services)
    {
        services.AddTransient(
            typeof(IPipelineBehavior<,>),
            typeof(ValidationBehavior<,>)
        );

        services.AddTransient(
            typeof(IPipelineBehavior<,>),
            typeof(CachingBehavior<,>)
        );

        return services;
    }

    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection") ?? "Data Source=app.db";

        services.AddDbContext<AppDbContext>(options => options.UseSqlite(connectionString));
        return services;
    }

    public static IServiceCollection AddIdentityServices(this IServiceCollection services)
    {
        services.AddDataProtection();

        services.AddIdentityCore<AppUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

        services.AddAuthorization();

        services.AddScoped<IIdentityService, IdentityService>();

        return services;
    }

    public static IServiceCollection AddTokenProvider(this IServiceCollection services)
    {
        services.AddScoped<ITokenProvider, TokenProvider>();
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