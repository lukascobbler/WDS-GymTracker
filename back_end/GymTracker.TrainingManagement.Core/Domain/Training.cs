using GymTracker.BuildingBlocks.Core.Domain;

namespace GymTracker.TrainingManagement.Core.Domain;

public class Training : Entity
{
    public int Duration { get; set; }
    public int CaloriesBurned { get; set; }
    public int TrainingDifficulty { get; set; } // from 1 to 10 in reference to average male / female athletes
    public int Tiredness { get; set; } // subjective feeling from 1 to 10
    public string? Notes { get; set; }
    public DateTime TrainingDate { get; set; }
    public TrainingType TrainingType { get; private set; }
}