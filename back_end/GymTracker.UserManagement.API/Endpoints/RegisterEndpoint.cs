using GymTracker.UserManagement.Core.Features.User.Commands.Register;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace GymTracker.UserManagement.API.Endpoints;

public static class RegisterEndpoint
{
    public static void MapRegister(this WebApplication app)
    {
        app.MapPost("api/v1/users/registration", async (RegisterCommand registerCommand, IMediator mediator) =>
        {
            var response = await mediator.Send(registerCommand);

            return response == null ? Results.BadRequest() : Results.Ok(response);
        });
    }
}