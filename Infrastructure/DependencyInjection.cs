using Application.Shared.Services;
using Infrastructure.Security;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.ConfigureOptions<JwtBearerOptionsSetup>();
        services.ConfigureOptions<JwtOptionsSetup>();
        services.AddAuthorization();
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
        services.AddScoped<IJwtProvider, JwtProvider>();

        services.AddScoped<IPasswordEncoder, PasswordEncoder>();

        return services;
    }
}