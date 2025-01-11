using GymTracker.UserManagement.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace GymTracker.UserManagement.Infrastructure.Database;

public class GymMembersContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<GymMember> GymMembers { get; set; }
    
    public GymMembersContext(DbContextOptions<GymMembersContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("gymMembers");
        
        ConfigureGymMember(modelBuilder);
    }

    private static void ConfigureGymMember(ModelBuilder modelBuilder)
    {
        
    }
}