using System.Reflection;
using Application.Behaviors;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();
        
        services.AddMediatR(configuration => 
            configuration.RegisterServicesFromAssembly(assembly));

        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddValidatorsFromAssembly(assembly, includeInternalTypes: true); 
        
        return services;
    }
}