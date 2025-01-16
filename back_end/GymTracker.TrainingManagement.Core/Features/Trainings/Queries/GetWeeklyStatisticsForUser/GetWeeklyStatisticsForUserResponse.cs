using System.ComponentModel.DataAnnotations.Schema;

namespace GymTracker.TrainingManagement.Core.Features.Trainings.Queries.GetWeeklyStatisticsForUser;

[NotMapped]
public record GetWeeklyStatisticsForUserResponse(int TotalTrainingTime, int NumberOfTrainings, 
    double AverageTrainingDifficulty, double AverageTrainingTiredness);