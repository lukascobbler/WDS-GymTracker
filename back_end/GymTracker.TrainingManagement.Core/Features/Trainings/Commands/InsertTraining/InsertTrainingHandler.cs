using GymTracker.TrainingManagement.Core.Domain;
using GymTracker.TrainingManagement.Core.Domain.RepositoryInterfaces;
using MediatR;

namespace GymTracker.TrainingManagement.Core.Features.Trainings.Commands.InsertTraining;

public class InsertTrainingHandler(ITrainingRepository trainingRepository, 
    ITrainingTypeRepository trainingTypeRepository): 
    IRequestHandler<InsertTrainingCommand, InsertTrainingResponse?>
{
    public async Task<InsertTrainingResponse?> Handle(InsertTrainingCommand request, CancellationToken cancellationToken)
    {
        var matchingTrainingType = await trainingTypeRepository.GetAsync(request.TrainingTypeId);
        if (matchingTrainingType == null)
        {
            return null;
        }
        
        var newTraining = new Training(
            request.Duration,
            request.CaloriesBurned,
            request.TrainingDifficulty,
            request.Tiredness,
            request.Notes,
            new DateOnly(request.Year, request.Month, request.Day),
            matchingTrainingType,
            request.GymMemberId
        ) {
            TrainingType = matchingTrainingType
        };
        
        return (await trainingRepository.Save(newTraining)).ToDto();
    }
}