using GymTracker.TrainingManagement.Core.Domain;

namespace GymTracker.TrainingManagement.Core.Features.Trainings.Queries.GetAllForUser;

public record GetAllForUserResponse(int Duration, int CaloriesBurned, int TrainingDifficulty, int Tiredness,
                          string TrainingTypeName, string? Notes, int Year, int Month, int Day);

public static class TrainingDtoExtensions
{
    public static GetAllForUserResponse ToDto(this Training training)
    {
        return new GetAllForUserResponse(training.Duration, training.CaloriesBurned, training.TrainingDifficulty, 
                               training.Tiredness, training.TrainingType.Name, training.Notes, 
                               training.TrainingDate.Year, training.TrainingDate.Month, training.TrainingDate.Day);
    }
}