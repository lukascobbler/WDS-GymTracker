using GymTracker.UserManagement.Core.Features.User.Register.Commands;
using MediatR;

namespace GymTracker.UserManagement.Core.Features.User.Register.Handlers;

public class RegisterHandler : IRequestHandler<RegisterCommand>
{
    public Task Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}