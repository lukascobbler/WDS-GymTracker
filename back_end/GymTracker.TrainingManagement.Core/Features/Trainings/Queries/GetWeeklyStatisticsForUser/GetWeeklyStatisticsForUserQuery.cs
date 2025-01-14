using MediatR;

namespace GymTracker.TrainingManagement.Core.Features.Trainings.Queries.GetWeeklyStatisticsForUser;

public record GetWeeklyStatisticsForUserQuery(DateOnly Date, int UserId): IRequest<List<GetWeeklyStatisticsForUserResponse>>;