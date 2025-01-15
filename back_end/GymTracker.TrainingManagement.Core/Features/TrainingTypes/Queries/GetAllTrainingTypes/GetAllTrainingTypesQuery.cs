using MediatR;

namespace GymTracker.TrainingManagement.Core.Features.TrainingTypes.Queries.GetAllTrainingTypes;

public record GetAllTrainingTypesQuery : IRequest<List<GetAllTrainingTypesResponse>>;