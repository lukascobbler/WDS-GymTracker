using GymTracker.TrainingManagement.Core.Domain;
using GymTracker.TrainingManagement.Core.Domain.RepositoryInterfaces;
using MediatR;

namespace GymTracker.TrainingManagement.Core.Features.Trainings.Queries.GetAllForUser;

public class GetAllForUserHandler(ITrainingRepository trainingRepository)
    : IRequestHandler<GetAllForUserQuery, List<GetAllForUserResponse>>
{
    public async Task<List<GetAllForUserResponse>> Handle(GetAllForUserQuery request, CancellationToken cancellationToken)
    {
        List<Training> trainingsForUser = await trainingRepository.GetAllForUserAsync(request.UserId);

        return trainingsForUser.Select(t => t.ToDto()).ToList();
    }
}