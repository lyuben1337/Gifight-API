using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Presentation;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        var assembly = typeof(DependencyInjection).Assembly;

        services.AddControllers().AddApplicationPart(assembly);

        return services;
    }
}