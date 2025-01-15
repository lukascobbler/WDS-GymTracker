using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using GymTracker.BuildingBlocks.Core.Domain;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

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
    [Column(TypeName = "varchar(255)")]
    public required string Name { get; set; }
    [Column(TypeName = "varchar(255)")]
    public required string Surname { get; set; }
    public Gender Gender { get; set; }
}

public enum Gender
{
    Male,
    Female
}