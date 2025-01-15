using MediatR;

namespace GymTracker.TrainingManagement.Core.Features.Trainings.Queries.GetWeeklyStatisticsForUser;

public record GetWeeklyStatisticsForUserQuery(int Year, int Month, int GymMemberId): IRequest<List<GetWeeklyStatisticsForUserResponse>>;