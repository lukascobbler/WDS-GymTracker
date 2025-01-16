using System.ComponentModel.DataAnnotations.Schema;
using GymTracker.BuildingBlocks.Core.Domain;

namespace GymTracker.UserManagement.Core.Domain;

public class User : Entity
{
    [Column(TypeName = "varchar(255)")]
    public required string Email { get; set; }
    [Column(TypeName = "varchar(1024)")]
    public required string Password { get; set; }
    [Column(TypeName = "varchar(4096)")]
    public required string Salt { get; set; }
    public bool IsActive { get; set; }
    public UserRole UserRole { get; private set; }
    
    public User() {}
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