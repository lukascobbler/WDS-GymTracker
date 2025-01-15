using GymTracker.UserManagement.Core.Features.User.Login;
using MediatR;
using Microsoft.AspNetCore.Builder;

namespace GymTracker.UserManagement.API.Endpoints;

public static class LoginEndpoint
{
    public static void MapLogin(this WebApplication app)
    {
        app.MapGet("api/v1/users/login", async (IMediator mediator, LoginQuery loginQuery) =>
        {
            return await mediator.Send(loginQuery);
        });
        
        // todo
    }
}