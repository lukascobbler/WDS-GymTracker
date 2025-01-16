using GymTracker.TrainingManagement.Core.Domain;
using GymTracker.TrainingManagement.Core.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace GymTracker.TrainingManagement.Infrastructure.Database.Repositories;

public class TrainingTypeRepository(TrainingContext context): ITrainingTypeRepository
{
    public Task<TrainingType?> GetAsync(int id)
    {
        return context
            .TrainingTypes
            .Where(tt => tt.Id == id)
            .FirstOrDefaultAsync();
    }

    public Task<List<TrainingType>> GetAllAsync()
    {
        return context
            .TrainingTypes
            .ToListAsync();
    }
}