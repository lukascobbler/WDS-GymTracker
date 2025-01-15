using GymTracker.TrainingManagement.Core.Features.Trainings.Queries.GetWeeklyStatisticsForUser;
using GymTracker.TrainingManagement.Core.Features.TrainingTypes.Queries.GetAllTrainingTypes;
using MediatR;
using Microsoft.AspNetCore.Builder;

namespace GymTracker.TrainingManagement.API.Endpoints;

public static class GetAllTrainingTypesEndpoint
{
    public static void MapAllTrainingTypesEndpoint(this WebApplication app)
    {
        app.MapGet("api/v1/trainingTypes/getAll", 
            async (IMediator mediator) =>
            { 
                return await mediator.Send(new GetAllTrainingTypesQuery());
            });
    }
}