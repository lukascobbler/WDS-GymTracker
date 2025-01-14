using GymTracker.UserManagement.Core.Domain;
using MediatR;

namespace GymTracker.UserManagement.Core.Features.User.Login;

public record LoginQuery(string Email, string Password) : IRequest<GymMember>;