using System.Data.Common;
using GymTracker.UserManagement.Core;
using GymTracker.UserManagement.Core.Domain;
using GymTracker.UserManagement.Core.Domain.RepositoryInterfaces;
using GymTracker.UserManagement.Infrastructure.Database;
using GymTracker.UserManagement.Infrastructure.Database.Repositories;
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

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IGymMemberRepository, GymMemberRepository>();
        
        return services;
    }
}