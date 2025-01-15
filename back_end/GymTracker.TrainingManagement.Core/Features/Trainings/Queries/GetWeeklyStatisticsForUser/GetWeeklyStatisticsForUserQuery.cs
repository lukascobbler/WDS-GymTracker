using MediatR;

namespace GymTracker.TrainingManagement.Core.Features.Trainings.Queries.GetWeeklyStatisticsForUser;

public record GetWeeklyStatisticsForUserQuery(int Year, int Month, int UserId): IRequest<List<GetWeeklyStatisticsForUserResponse>>;