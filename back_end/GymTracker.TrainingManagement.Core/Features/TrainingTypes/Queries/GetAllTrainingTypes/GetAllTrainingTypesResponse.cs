using GymTracker.TrainingManagement.Core.Domain;

namespace GymTracker.TrainingManagement.Core.Features.TrainingTypes.Queries.GetAllTrainingTypes;

public record GetAllTrainingTypesResponse(int TrainingTypeId, string TrainingTypeName);

public static class TrainingDtoExtensions
{
    public static GetAllTrainingTypesResponse ToDto(this TrainingType trainingType)
    {
        return new GetAllTrainingTypesResponse(trainingType.Id, trainingType.Name);
    }
}