using GymTracker.BuildingBlocks.Infrastructure;
using GymTracker.TrainingManagement.Core.Domain.RepositoryInterfaces;
using GymTracker.TrainingManagement.Infrastructure.Database;
using GymTracker.TrainingManagement.Infrastructure.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GymTracker.TrainingManagement.Infrastructure;

public static class TrainingInfrastructureStartup
{
    public static IServiceCollection ConfigureTrainingModule(this IServiceCollection services)
    {
        services.AddDbContext<TrainingContext>(options =>
            options.UseNpgsql(DbConnectionStringBuilder.Build("trainings"),
                x => x.MigrationsHistoryTable("__EFMigrationsHistory", "trainings")));
        
        services.AddScoped<ITrainingRepository, TrainingRepository>();
        services.AddScoped<ITrainingTypeRepository, TrainingTypeRepository>();
        
        return services;
    }
}