using GymTracker.UserManagement.Core.Domain;
using MediatR;

namespace GymTracker.UserManagement.Core.Features.User.Register;

public record RegisterCommand(
    string Email, 
    string Password, 
    string RepeatPassword,
    string Name, 
    string Surname, 
    Gender Gender) : IRequest<RegisterResponse>;