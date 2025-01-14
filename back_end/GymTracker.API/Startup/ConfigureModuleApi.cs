using GymTracker.TrainingManagement.API;

namespace GymTracker.API.Startup;

public static class ConfigureModuleApi
{
    public static void RegisterModuleEndpoints(this WebApplication app)
    {
        app.AddTrainingEndpoints();
    }
}