using GymTracker.UserManagement.Core.Features.User.Register;
using MediatR;
using Microsoft.AspNetCore.Builder;

namespace GymTracker.UserManagement.API.Endpoints;

public static class RegisterEndpoint
{
    public static void MapRegister(this WebApplication app)
    {
        app.MapGet("api/v1/users/register", async (IMediator mediator, RegisterCommand registerCommand) =>
        {
            return await mediator.Send(registerCommand);
        });
    }
}