namespace GymTracker.UserManagement.Core.Domain.RepositoryInterfaces;

public interface IUserRepository
{
    Task<User?> GetByCredentials(string email, string password);
    Task<User> Save(User user);
    Task<bool> EmailExists(string email);
}