using GymTracker.TrainingManagement.Infrastructure.Authentication;
using GymTracker.UserManagement.Core.Domain;
using GymTracker.UserManagement.Core.Domain.RepositoryInterfaces;
using MediatR;

namespace GymTracker.UserManagement.Core.Features.User.Commands.Register;

public class RegisterHandler(IGymMemberRepository gymMemberRepository, 
    IUserRepository userRepository): IRequestHandler<RegisterCommand, RegisterResponse?>
{
    public async Task<RegisterResponse?> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        if (await userRepository.EmailExists(request.Email))
        {
            return null;
        }

        if (request.Password != request.RepeatPassword)
        {
            return null;
        }
        
        var salt = PasswordUtilities.GenerateSalt();
        var hashedPassword = PasswordUtilities.HashPassword(request.Password, salt);
        var user = new Domain.User(request.Email, hashedPassword, Convert.ToBase64String(salt), UserRole.RegularUser)
        {
            Email = request.Email,
            Password = hashedPassword,
            Salt = Convert.ToBase64String(salt),
        };
        // the role is fixed for now because there is no feature request for it
        await userRepository.Save(user);

        var gymMember = new GymMember(user, request.Name, request.Surname, request.Gender)
        {
            Name = request.Name,
            Surname = request.Surname,
            User = user
        };
        
        await gymMemberRepository.Save(gymMember);
        
        return new RegisterResponse(gymMember.Id);
    }
}