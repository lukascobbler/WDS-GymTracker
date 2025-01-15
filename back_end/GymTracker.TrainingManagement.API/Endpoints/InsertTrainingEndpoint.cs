using GymTracker.TrainingManagement.Core.Features.Trainings.Commands.InsertTraining;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace GymTracker.TrainingManagement.API.Endpoints;

public static class InsertTrainingEndpoint
{
    public static void MapInsertTrainingEndpoint(this WebApplication app)
    {
        app.MapPost("api/v1/trainings", async (InsertTrainingCommand insertTrainingCommand, IMediator mediator) =>
        {
            var newTraining = await mediator.Send(insertTrainingCommand);

            return newTraining == null ? Results.BadRequest() : Results.Created("/api/v1/trainings", newTraining);
        });
    }
}