using GymTracker.UserManagement.Core.Domain;
using MediatR;

namespace GymTracker.UserManagement.Core.Features.User.Login;

public class LoginHandler : IRequestHandler<LoginQuery, GymMember>
{
    public Task<GymMember> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}