namespace GymTracker.TrainingManagement.Core.Features.Trainings.Queries.GetWeeklyStatisticsForUser;

public record GetWeeklyStatisticsForUserResponse(int TotalTrainingTime, int NumberOfTrainings, 
    int AverageTrainingDifficulty, int AverageTrainingTiredness);