using GymTracker.TrainingManagement.Core.Features.Trainings.Commands.InsertTraining;
using MediatR;
using Microsoft.AspNetCore.Builder;

namespace GymTracker.TrainingManagement.API.Endpoints;

public static class InsertTrainingEndpoint
{
    public static void MapInsertTrainingEndpoint(this WebApplication app)
    {
        app.MapPost("api/v1/trainings", async (InsertTrainingCommand insertTrainingCommand, IMediator mediator) =>
        {
            await mediator.Send(insertTrainingCommand);
        });
        
        // todo
    }
}