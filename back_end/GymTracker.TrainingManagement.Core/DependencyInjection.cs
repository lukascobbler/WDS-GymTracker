using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace GymTracker.TrainingManagement.Core;

public static class DependencyInjection
{
    public static IServiceCollection ConfigureTrainingModuleCoreDependencyInjection(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        
        return services;
    }
}