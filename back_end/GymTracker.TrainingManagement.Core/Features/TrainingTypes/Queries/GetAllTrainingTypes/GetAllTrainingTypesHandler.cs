using GymTracker.TrainingManagement.Core.Domain;
using GymTracker.TrainingManagement.Core.Domain.RepositoryInterfaces;
using MediatR;

namespace GymTracker.TrainingManagement.Core.Features.TrainingTypes.Queries.GetAllTrainingTypes;

public class GetAllTrainingTypesHandler(ITrainingTypeRepository trainingTypeRepository)
    : IRequestHandler<GetAllTrainingTypesQuery, List<GetAllTrainingTypesResponse>>
{
    public async Task<List<GetAllTrainingTypesResponse>> Handle(GetAllTrainingTypesQuery request, CancellationToken cancellationToken)
    {
        List<TrainingType> allTrainingTypes = await trainingTypeRepository.GetAllAsync();

        return allTrainingTypes.Select(t => t.ToDto()).ToList();
    }
}