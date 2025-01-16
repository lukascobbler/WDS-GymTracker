using MediatR;

namespace GymTracker.UserManagement.Core.Features.User.Queries.Login;

public record LoginQuery(string Email, string Password) : IRequest<LoginResponse?>;