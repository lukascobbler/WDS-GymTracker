using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace GymTracker.UserManagement.Core;

public static class DependencyInjection
{
    public static IServiceCollection ConfigureUserModuleCoreDependencyInjection(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        
        return services;
    }
}