using MediatR;

namespace GymTracker.TrainingManagement.Core.Features.Trainings.Commands.InsertTraining;

public record InsertTrainingCommand(int Duration, int CaloriesBurned, int TrainingDifficulty,
                                      int Tiredness, string? Notes, int TrainingTypeId,
                                      DateOnly TrainingDate, int UserId): IRequest<InsertTrainingResponse>;