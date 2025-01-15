using GymTracker.UserManagement.Core.Domain;
using GymTracker.UserManagement.Core.Domain.RepositoryInterfaces;
using MediatR;

namespace GymTracker.UserManagement.Core.Features.User.Login;

public class LoginHandler(IUserRepository userRepository,
    IGymMemberRepository gymMemberRepository): IRequestHandler<LoginQuery, LoginResponse>
{
    public async Task<LoginResponse> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByCredentials(request.Email, request.Password);

        if (user != null)
        {
            // todo error
        }
        
        var gymMember = gymMemberRepository.GetByUserId(user.Id);
        
        return new LoginResponse(gymMember.Id);
    }
}