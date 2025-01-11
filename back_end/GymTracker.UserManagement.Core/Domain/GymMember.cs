namespace GymTracker.UserManagement.Core.Domain;

public class GymMember
{
    private User User { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public Gender Gender { get; set; }
}

public enum Gender
{
    Male,
    Female
}