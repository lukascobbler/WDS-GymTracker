using System.Data.Common;
using GymTracker.UserManagement.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DbConnectionStringBuilder = GymTracker.BuildingBlocks.Infrastructure.DbConnectionStringBuilder;

namespace GymTracker.UserManagement.Infrastructure;

public static class UserManagementSetup
{
    public static IServiceCollection ConfigureUsersModule(this IServiceCollection services)
    {
        services.AddDbContext<UsersContext>(options =>
            options.UseNpgsql(DbConnectionStringBuilder.Build("users"),
                x => x.MigrationsHistoryTable("__EFMigrationsHistory", "users")));
        
        return services;
    }
}