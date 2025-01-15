using GymTracker.TrainingManagement.Core.Domain;
using GymTracker.TrainingManagement.Core.Domain.RepositoryInterfaces;
using GymTracker.TrainingManagement.Core.Features.Trainings.Queries.GetWeeklyStatisticsForUser;
using Microsoft.EntityFrameworkCore;

namespace GymTracker.TrainingManagement.Infrastructure.Database.Repositories;

public class TrainingRepository(TrainingContext context) : ITrainingRepository
{
    public Task<List<Training>> GetAllForUserAsync(int userId)
    {
        return context.Trainings
            .Where(t => t.GymMemberId == userId)
            .Include(t => t.TrainingType)
            .OrderByDescending(t => t.TrainingDate)
            .ToListAsync();
    }

    public Task<List<Training>> GetTrainingsForMonthForYearForUserAsync(int year, int month, int userId)
    {
        return context.Trainings
            .Where(t => t.GymMemberId == userId)
            .Where(t => t.TrainingDate.Year == year && t.TrainingDate.Month == month)
            .ToListAsync();
    }

    public async Task<Training> Save(Training training)
    {
        await context.Trainings.AddAsync(training);
        await context.SaveChangesAsync();

        return training;
    }
}