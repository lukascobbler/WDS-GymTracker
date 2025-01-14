using GymTracker.TrainingManagement.Core.Domain;
using GymTracker.TrainingManagement.Core.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace GymTracker.TrainingManagement.Infrastructure.Database.Repositories;

public class TrainingRepository(TrainingContext context) : ITrainingRepository
{
    public Task<List<Training>> GetAllForUserAsync(int userId)
    {
        return context.Trainings
            .Where(t => t.UserId == userId)
            .Include(t => t.TrainingType)
            .ToListAsync();
    }

    public async Task<Training> Save(Training training)
    {
        await context.Trainings.AddAsync(training);
        await context.SaveChangesAsync();

        return training;
    }
}