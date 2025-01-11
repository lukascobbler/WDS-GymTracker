using GymTracker.BuildingBlocks.Infrastructure;
using GymTracker.TrainingManagement.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GymTracker.TrainingManagement.Infrastructure;

public static class TrainingManagementStartup
{
    public static IServiceCollection ConfigureTrainingModule(this IServiceCollection services)
    {
        services.AddDbContext<TrainingContext>(options =>
            options.UseNpgsql(DbConnectionStringBuilder.Build("trainings"),
                x => x.MigrationsHistoryTable("__EFMigrationsHistory", "trainings")));
        
        return services;
    }
}