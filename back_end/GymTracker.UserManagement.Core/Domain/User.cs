using GymTracker.BuildingBlocks.Core.Domain;

namespace GymTracker.UserManagement.Core.Domain;

public class User : Entity
{
    public string Email { get; internal set; }
    public string Password { get; private set; }
    public string Salt { get; private set; }
    public bool IsActive { get; set; }
    public UserRole UserRole { get; private set; }
    
    public User(string email, string password, string salt, UserRole role)
    {
        Email = email;
        Password = password;
        Salt = salt;
        UserRole = role;
        IsActive = true;
    }
}

public enum UserRole
{
    Admin,
    RegularUser,
}