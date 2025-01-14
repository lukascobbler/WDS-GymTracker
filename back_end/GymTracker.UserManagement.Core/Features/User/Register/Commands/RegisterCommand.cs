using GymTracker.UserManagement.Core.Domain;
using MediatR;

namespace GymTracker.UserManagement.Core.Features.User.Register.Commands;

public record RegisterCommand(
    string Email, 
    string Password, 
    string Name, 
    string Surname, 
    Gender Gender) : IRequest;