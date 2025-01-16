using GymTracker.TrainingManagement.Core;
using GymTracker.UserManagement.Core;

namespace GymTracker.API.Startup;

public static class ConfigureModuleDependencyInjection
{
    public static IServiceCollection RegisterModuleDependencyInjection(this IServiceCollection services)
    {
        services.ConfigureTrainingModuleCoreDependencyInjection();
        services.ConfigureUserModuleCoreDependencyInjection();
        
        return services;
    }
}