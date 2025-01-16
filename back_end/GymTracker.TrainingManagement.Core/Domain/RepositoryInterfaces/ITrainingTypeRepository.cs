namespace GymTracker.TrainingManagement.Core.Domain.RepositoryInterfaces;

public interface ITrainingTypeRepository
{
    Task<TrainingType?> GetAsync(int id);
    Task<List<TrainingType>> GetAllAsync();
}