using GymTracker.TrainingManagement.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace GymTracker.TrainingManagement.Infrastructure.Database;

public class TrainingContext : DbContext
{
    public DbSet<Training> Trainings { get; set; }
    public DbSet<TrainingType> TrainingTypes { get; set; }
    
    public TrainingContext(DbContextOptions<TrainingContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("trainingSchema");
        
        ConfigureTrainings(modelBuilder);
    }

    private static void ConfigureTrainings(ModelBuilder modelBuilder)
    {
        
    }
}