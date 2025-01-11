using GymTracker.TrainingManagement.Infrastructure;
using GymTracker.UserManagement.Infrastructure;

namespace GymTracker.API.Startup;

public static class ConfigureModules
{
    public static IServiceCollection RegisterModules(this IServiceCollection services)
    {
        services.ConfigureTrainingModule();
        services.ConfigureUsersModule();
        
        return services;
    }
}