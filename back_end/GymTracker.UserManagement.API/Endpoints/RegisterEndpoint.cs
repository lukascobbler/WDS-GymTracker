using GymTracker.UserManagement.Core.Features.User.Register;
using MediatR;
using Microsoft.AspNetCore.Builder;

namespace GymTracker.UserManagement.API.Endpoints;

public static class RegisterEndpoint
{
    public static void MapRegister(this WebApplication app)
    {
        app.MapPost("api/v1/users/registration", async (RegisterCommand registerCommand, IMediator mediator) =>
        {
            return await mediator.Send(registerCommand);
        });
    }
}