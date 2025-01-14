using GymTracker.TrainingManagement.Core.Features.Trainings.Queries.GetAllForUser;
using GymTracker.TrainingManagement.Core.Features.Trainings.Queries.GetWeeklyStatisticsForUser;
using MediatR;
using Microsoft.AspNetCore.Builder;

namespace GymTracker.TrainingManagement.API.Endpoints;

public static class GetWeeklyStatisticsForUserEndpoint
{
    public static void MapGetWeeklyStatisticsForUserEndpoint(this WebApplication app)
    {
        app.MapGet("api/v1/trainings/{userId:int}/statistics/{date}", 
            async (IMediator mediator, int userId, DateOnly date) =>
        { 
            var getAll = new GetWeeklyStatisticsForUserQuery(date, userId);
            
            return await mediator.Send(getAll);
        });
    }
}