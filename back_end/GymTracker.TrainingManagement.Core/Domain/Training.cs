using GymTracker.BuildingBlocks.Core.Domain;

namespace GymTracker.TrainingManagement.Core.Domain;

public class Training : Entity
{
    public Training() { }
    public Training(int duration, int caloriesBurned, int trainingDifficulty, int tiredness, string? notes, DateOnly trainingDate, TrainingType trainingType, int userId)
    {
        Duration = duration;
        CaloriesBurned = caloriesBurned;
        TrainingDifficulty = trainingDifficulty;
        Tiredness = tiredness;
        Notes = notes;
        TrainingDate = trainingDate;
        TrainingType = trainingType;
        UserId = userId;
    }

    public int Duration { get; set; }
    public int CaloriesBurned { get; set; }
    public int TrainingDifficulty { get; set; } // from 1 to 10 in reference to average male / female athletes
    public int Tiredness { get; set; } // subjective feeling from 1 to 10
    public string? Notes { get; set; }
    public DateOnly TrainingDate { get; set; }
    public required TrainingType TrainingType { get; set; }
    public int UserId { get; set; }
}