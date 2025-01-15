using GymTracker.UserManagement.Core.Features.User.Login;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;

namespace GymTracker.UserManagement.API.Endpoints;

public static class LoginEndpoint
{
    public static void MapLogin(this WebApplication app)
    {
        app.MapPost("api/v1/users/login", async (LoginQuery loginQuery, IMediator mediator) =>
        {
            var loginReponse = await mediator.Send(loginQuery);

            return loginReponse == null ? Results.NotFound() : Results.Ok(loginReponse);
        });
    }
}