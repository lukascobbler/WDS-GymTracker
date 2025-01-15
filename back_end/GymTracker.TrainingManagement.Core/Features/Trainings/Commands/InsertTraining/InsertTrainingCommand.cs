using MediatR;

namespace GymTracker.TrainingManagement.Core.Features.Trainings.Commands.InsertTraining;

public record InsertTrainingCommand(int Duration, int CaloriesBurned, int TrainingDifficulty,
                                      int Tiredness, string? Notes, int TrainingTypeId,
                                      int Year, int Month, int Day, int GymMemberId): IRequest<InsertTrainingResponse?>;