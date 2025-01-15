using GymTracker.TrainingManagement.API.Endpoints;
using Microsoft.AspNetCore.Builder;

namespace GymTracker.TrainingManagement.API;

public static class TrainingApiStartup
{
    public static void AddTrainingEndpoints(this WebApplication app)
    {
        app.MapInsertTrainingEndpoint();
        app.MapGetAllTrainingsForUserEndpoint();
        app.MapGetWeeklyStatisticsForUserEndpoint();
        app.MapAllTrainingTypesEndpoint();
    }
}