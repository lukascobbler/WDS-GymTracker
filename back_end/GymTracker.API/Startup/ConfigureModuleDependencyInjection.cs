using GymTracker.TrainingManagement.Core;

namespace GymTracker.API.Startup;

public static class ConfigureModuleDependencyInjection
{
    public static IServiceCollection RegisterModuleDependencyInjection(this IServiceCollection services)
    {
        services.ConfigureTrainingModuleCoreDependencyInjection();
        
        return services;
    }
}