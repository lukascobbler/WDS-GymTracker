using GymTracker.UserManagement.Core.Domain;
using GymTracker.UserManagement.Core.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace GymTracker.UserManagement.Infrastructure.Database.Repositories;

public class GymMemberRepository(UsersContext usersContext): IGymMemberRepository
{
    public Task<GymMember?> Get(int gymMemberId)
    {
        return usersContext
            .GymMembers
            .Where(u => u.Id == gymMemberId)
            .FirstOrDefaultAsync();
    }
    
    public Task<GymMember?> GetByUserId(int userId)
    {
        return usersContext
            .GymMembers
            .Include(g => g.User)
            .Where(g => g.User.Id == userId)
            .FirstOrDefaultAsync();
    }

    public async Task<GymMember> Save(GymMember gymMember)
    {
        await usersContext.GymMembers.AddAsync(gymMember); 
        await usersContext.SaveChangesAsync();
        
        return gymMember;
    }
}