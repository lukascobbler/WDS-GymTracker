using MediatR;

namespace GymTracker.TrainingManagement.Core.Features.Trainings.Queries.GetAllForUser;

public record GetAllForUserQuery(int UserId) : IRequest<List<GetAllForUserResponse>>;