using MediatR;

namespace GymTracker.TrainingManagement.Core.Features.Trainings.Queries.GetWeeklyStatisticsForUser;

public class GetWeeklyStatisticsForUserHandler: IRequestHandler<GetWeeklyStatisticsForUserQuery, List<GetWeeklyStatisticsForUserResponse>>
{
    public Task<List<GetWeeklyStatisticsForUserResponse>> Handle(GetWeeklyStatisticsForUserQuery request, CancellationToken cancellationToken)
    {
        // todo
        return Task.FromResult(new List<GetWeeklyStatisticsForUserResponse>([
            new GetWeeklyStatisticsForUserResponse(0, 0, 0, 0),
            new GetWeeklyStatisticsForUserResponse(0, 0, 0, 0),
            new GetWeeklyStatisticsForUserResponse(0, 0, 0, 0),
            new GetWeeklyStatisticsForUserResponse(0, 0, 0, 0)
        ])) ;
    }
}