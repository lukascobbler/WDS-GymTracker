using GymTracker.UserManagement.API.Endpoints;
using Microsoft.AspNetCore.Builder;

namespace GymTracker.UserManagement.API;

public static class UsersApiStartup
{
    public static void AddUsersEndpoints(this WebApplication app)
    {
        app.MapLogin();
        app.MapRegister();
    }
}