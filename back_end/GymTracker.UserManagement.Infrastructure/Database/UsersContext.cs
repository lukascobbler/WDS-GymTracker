using GymTracker.UserManagement.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace GymTracker.UserManagement.Infrastructure.Database;

public class UsersContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<GymMember> GymMembers { get; set; }
    
    public UsersContext(DbContextOptions<UsersContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("users");
        
        ConfigureGymMember(modelBuilder);
    }

    private static void ConfigureGymMember(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GymMember>()
            .HasOne<User>()
            .WithOne();
    }
}