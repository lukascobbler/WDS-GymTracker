using GymTracker.TrainingManagement.Core.Domain.RepositoryInterfaces;
using MediatR;

namespace GymTracker.TrainingManagement.Core.Features.Trainings.Queries.GetWeeklyStatisticsForUser;

public class GetWeeklyStatisticsForUserHandler(ITrainingRepository trainingRepository): IRequestHandler<GetWeeklyStatisticsForUserQuery, List<GetWeeklyStatisticsForUserResponse>>
{
    public async Task<List<GetWeeklyStatisticsForUserResponse>> Handle(GetWeeklyStatisticsForUserQuery request, CancellationToken cancellationToken)
    {
        var trainings =
            await trainingRepository.GetTrainingsForMonthForYearForUserAsync(request.Year, request.Month, request.GymMemberId);

        var dateIter = new DateOnly(request.Year, request.Month, 1);
        
        // you can have 4 weeks only in the month of february and if the 1st of february that year is a monday
        var responses = Enumerable
            .Range(0, dateIter is { DayOfWeek: DayOfWeek.Monday, Month: 2 } ? 4 : 5)
            .Select(_ => new WeeklyStatistics())
            .ToList();
        
        var endingDate = dateIter.AddMonths(1);
        var sundayDays = new List<int>();

        while (dateIter < endingDate)
        {
            if (dateIter.DayOfWeek == DayOfWeek.Sunday)
            {
                sundayDays.Add(dateIter.Day);
            }
            
            dateIter = dateIter.AddDays(1);
        }
        
        foreach (var t in trainings)
        {
            int trainingWeek;

            if (t.TrainingDate.Day <= sundayDays[0])
            {
                trainingWeek = 0;
            } else if (t.TrainingDate.Day <= sundayDays[1])
            {
                trainingWeek = 1;
            } else if (t.TrainingDate.Day <= sundayDays[2])
            {
                trainingWeek = 2;
            } else if (t.TrainingDate.Day <= sundayDays[3])
            {
                trainingWeek = 3;
            } else 
            {
                trainingWeek = 4;
            }

            responses[trainingWeek].NumberOfTrainings++;
            responses[trainingWeek].TotalTrainingTime += t.Duration;
            responses[trainingWeek].TotalTrainingDifficulty += t.TrainingDifficulty;
            responses[trainingWeek].TotalTrainingTiredness += t.Tiredness;
        }

        return responses.Select(ws => new GetWeeklyStatisticsForUserResponse(
            ws.TotalTrainingTime, 
            ws.NumberOfTrainings,
            ws.GetAverageTrainingDifficulty(),
            ws.GetAverageTrainingTiredness())
        ).ToList();
    }
}

internal class WeeklyStatistics
{
    public int TotalTrainingTime;
    public int NumberOfTrainings;
    public int TotalTrainingDifficulty;
    public int TotalTrainingTiredness;

    public double GetAverageTrainingDifficulty()
    {
        return NumberOfTrainings == 0 ? 0 : TotalTrainingDifficulty / (double) NumberOfTrainings;
    }

    public double GetAverageTrainingTiredness()
    {
        return NumberOfTrainings == 0 ? 0 : TotalTrainingTiredness / (double) NumberOfTrainings;
    }
}