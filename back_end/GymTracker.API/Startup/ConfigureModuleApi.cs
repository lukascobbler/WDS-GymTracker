using GymTracker.TrainingManagement.API;
using GymTracker.UserManagement.API;

namespace GymTracker.API.Startup;

public static class ConfigureModuleApi
{
    public static void RegisterModuleEndpoints(this WebApplication app)
    {
        app.AddTrainingEndpoints();
        app.AddUsersEndpoints();
    }
}