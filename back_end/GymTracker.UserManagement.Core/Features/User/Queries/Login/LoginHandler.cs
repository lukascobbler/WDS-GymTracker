using GymTracker.UserManagement.Core.Domain.RepositoryInterfaces;
using MediatR;

namespace GymTracker.UserManagement.Core.Features.User.Queries.Login;

public class LoginHandler(IUserRepository userRepository,
    IGymMemberRepository gymMemberRepository): IRequestHandler<LoginQuery, LoginResponse?>
{
    public async Task<LoginResponse?> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByCredentials(request.Email, request.Password);

        if (user == null)
        {
            return null;
        }

        if (!user.IsActive)
        {
            return null;
        }

        var gymMember = await gymMemberRepository.GetByUserId(user.Id);
        
        return new LoginResponse(gymMember!.Id);
    }
}