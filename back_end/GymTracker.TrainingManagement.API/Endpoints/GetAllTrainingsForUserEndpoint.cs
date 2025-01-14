using GymTracker.TrainingManagement.Core.Features.Trainings.Queries.GetAllForUser;
using MediatR;
using Microsoft.AspNetCore.Builder;

namespace GymTracker.TrainingManagement.API.Endpoints;

public static class GetAllTrainingsForUserEndpoint
{
    public static void MapGetAllTrainingsForUserEndpoint(this WebApplication app)
    {
        app.MapGet("api/v1/trainings/{userId:int}", async (IMediator mediator, int userId) =>
        {
            var getAll = new GetAllForUserQuery(userId);
            
            return await mediator.Send(getAll);
        });
    }
}