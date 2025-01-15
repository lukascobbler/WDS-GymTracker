using GymTracker.BuildingBlocks.Core.Domain;

namespace GymTracker.UserManagement.Core.Domain;

public class GymMember: Entity
{
    public GymMember() {}

    public GymMember(User user, string name, string surname, Gender gender)
    {
        User = user;
        Name = name;
        Surname = surname;
        Gender = gender;
    }

    public required User User { get; set; }
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public Gender Gender { get; set; }
}

public enum Gender
{
    Male,
    Female
}