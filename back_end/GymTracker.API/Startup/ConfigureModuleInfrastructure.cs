using GymTracker.TrainingManagement.API;
using GymTracker.TrainingManagement.Core;
using GymTracker.TrainingManagement.Infrastructure;
using GymTracker.UserManagement.Infrastructure;

namespace GymTracker.API.Startup;

public static class ConfigureModuleInfrastructure
{
    public static IServiceCollection RegisterModuleInfrastructure(this IServiceCollection services)
    {
        services.ConfigureTrainingModule();
        services.ConfigureUsersModule();
        
        return services;
    }
}