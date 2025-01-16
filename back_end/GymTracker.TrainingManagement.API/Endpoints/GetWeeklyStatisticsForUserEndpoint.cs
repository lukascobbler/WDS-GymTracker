using GymTracker.TrainingManagement.Core.Features.Trainings.Queries.GetAllForUser;
using GymTracker.TrainingManagement.Core.Features.Trainings.Queries.GetWeeklyStatisticsForUser;
using MediatR;
using Microsoft.AspNetCore.Builder;

namespace GymTracker.TrainingManagement.API.Endpoints;

public static class GetWeeklyStatisticsForUserEndpoint
{
    public static void MapGetWeeklyStatisticsForUserEndpoint(this WebApplication app)
    {
        app.MapGet("api/v1/trainings/{userId:int}/statistics/{year:int}/{month:int}", 
            async (IMediator mediator, int userId, int year, int month) =>
        { 
            var getAll = new GetWeeklyStatisticsForUserQuery(year, month, userId);
            
            return await mediator.Send(getAll);
        });
    }
}