namespace GymTracker.TrainingManagement.Core.Domain.RepositoryInterfaces;

public interface ITrainingRepository
{
    Task<List<Training>> GetAllForUserAsync(int userId);
    Task<Training> Save(Training training);
}