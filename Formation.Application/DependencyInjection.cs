using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Formation.Application.Common.Pipelines;

namespace Formation.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var ass = Assembly.GetExecutingAssembly();

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        return services;
    }
}
