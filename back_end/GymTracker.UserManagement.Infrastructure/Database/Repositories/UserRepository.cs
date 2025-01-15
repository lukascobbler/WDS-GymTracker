using GymTracker.TrainingManagement.Infrastructure.Authentication;
using GymTracker.UserManagement.Core.Domain;
using GymTracker.UserManagement.Core.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace GymTracker.UserManagement.Infrastructure.Database.Repositories;

public class UserRepository(UsersContext usersContext): IUserRepository
{
    public async Task<User?> GetByCredentials(string email, string password)
    {
        var foundUserWithEmail = await usersContext
            .Users
            .Where(u => u.Email == email)
            .FirstOrDefaultAsync();

        if (foundUserWithEmail == null || IsPasswordIncorrect(foundUserWithEmail, password))
        {
            // todo error
        }
        
        return foundUserWithEmail;
    }

    public async Task<User> Save(User user)
    {
        await usersContext.AddAsync(user);
        await usersContext.SaveChangesAsync();
        
        return user;
    }

    public Task<bool> EmailExists(string email)
    {
        return usersContext
            .Users
            .AnyAsync(u => u.Email == email);
    }
    
    private static bool IsPasswordIncorrect(User user, string password)
    {
        return !user.Password.Equals(PasswordUtilities.HashPassword(password, Convert.FromBase64String(user.Salt)));
    }
}